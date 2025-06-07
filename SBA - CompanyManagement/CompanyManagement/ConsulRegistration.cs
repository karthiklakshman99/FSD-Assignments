using Consul;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace CompanyManagement
{
    public static class ConsulRegistration
    {
        public static void RegisterWithConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime)
        {
            var consulClient = new ConsulClient(config => config.Address = new Uri("http://localhost:8500"));
            var serviceId = $"company-api-{Guid.NewGuid()}";

            var features = app.ServerFeatures.Get<IServerAddressesFeature>();
            var address = features.Addresses.First();

            var uri = new Uri(address);
            var registration = new AgentServiceRegistration
            {
                ID = serviceId,
                Name = "CompanyManagementAPI",
                Address = uri.Host,
                Port = uri.Port,
                Check = new AgentServiceCheck
                {
                    HTTP = $"{address}/health",
                    Interval = TimeSpan.FromSeconds(30),
                    Timeout = TimeSpan.FromSeconds(5)
                }
            };

            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(serviceId).Wait();
            });
        }
    }

}
