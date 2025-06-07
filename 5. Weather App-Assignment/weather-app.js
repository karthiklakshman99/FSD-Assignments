const weatherForm = document.getElementById("weather-form");
const cityInput = document.getElementById("city-input");
const weatherResult = document.getElementById("weather-result");
const errorMessage = document.getElementById("error-message");

const API_KEY = "77baa371e4eec312a15b2eb55db21d35";

weatherForm.addEventListener("submit", async (e) => {
  e.preventDefault();
  const city = cityInput.value.trim();

  weatherResult.innerHTML = "";
  errorMessage.textContent = "";

  if (city === "") {
    errorMessage.textContent = "Please enter a city name.";
    return;
  }

  try {
    const response = await fetch(
      `https://api.openweathermap.org/data/2.5/weather?q=${city}&appid=${API_KEY}&units=metric`
    );

    if (!response.ok) {
      throw new Error("City not found. Please check the city name.");
    }

    const data = await response.json();

    displayWeather(data);
  } catch (error) {
    errorMessage.textContent = error.message;
  }
});

function displayWeather(data) {
  const { name, main, weather, wind } = data;

  weatherResult.innerHTML = `
    <h2>${name}</h2>
    <img src="https://openweathermap.org/img/wn/${weather[0].icon}@2x.png" alt="${weather[0].description}">
    <p>Temperature: ${main.temp}°C</p>
    <p>Weather: ${weather[0].description}</p>
    <p>Humidity: ${main.humidity}%</p>
    <p>Wind Speed: ${wind.speed} m/s</p>
  `;
}
