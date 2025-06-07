using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using NoteService.Models;

namespace InfraSetup
{
    public class NoteDbFixture : IDisposable
    {
        private IConfigurationRoot configuration;
        public NoteContext context;

        public NoteDbFixture()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            configuration = builder.Build();
            context = new NoteContext(configuration);
            context.Notes.DeleteMany(Builders<Note>.Filter.Empty);
            context.Notes.InsertMany(new List<Note>
                {
                    new()
                    {
                        Id = 101,
                        Category = new Category
                        {
                            Id = 101,
                            Name = "Sports",
                            CreatedBy = "Mukesh",
                            Description = "All about sports",
                            CreationDate = DateTime.Now
                        },
                        Reminders = new List<Reminder>
                        {
                            new Reminder
                            {
                                Id = 201,
                                Name = "Sports",
                                CreatedBy = "Mukesh",
                                Description = "sports reminder",
                                CreationDate = DateTime.Now,
                                Type = "email"
                            }
                        },
                        CreationDate = DateTime.Now
                    },
                    new Note
                    {
                        Id = 102,
                        Category = new Category
                        {
                            Id = 102,
                            Name = "Sports",
                            CreatedBy = "Sachin",
                            Description = "All about sports",
                            CreationDate = DateTime.Now
                        },
                        Reminders = new List<Reminder>
                        {
                            new Reminder
                            {
                                Id = 202,
                                Name = "Sports",
                                CreatedBy = "Sachin",
                                Description = "sports reminder",
                                CreationDate = DateTime.Now,
                                Type = "email"
                            }
                        },
                        CreationDate = DateTime.Now
                    }
                });
        }

        public void Dispose()
        {
            context = null;
        }
    }
}

