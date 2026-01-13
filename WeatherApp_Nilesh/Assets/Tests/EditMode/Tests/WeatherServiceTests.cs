using NUnit.Framework;
using UnityEngine;

public class WeatherServiceTests
{
    private WeatherService weatherService;

    [SetUp]
    public void Setup()
    {
        var go = new GameObject("WeatherService_Test");
        weatherService = go.AddComponent<WeatherService>();
    }

    [Test]
    public void ParseTemperature_ValidJson_ReturnsFirstTemperature()
    {
        string json = @"{
            ""daily"": {
                ""temperature_2m_max"": [32, 34.5, 33.5]
            }
        }";

        float temp = weatherService.ParseTemperatureFromJson(json);

        Assert.AreEqual(32f, temp);
    }

    [Test]
    public void ParseTemperature_ValidJsonWithSingleValue_ReturnsThatValue()
    {
        string json = @"{
            ""daily"": {
                ""temperature_2m_max"": [28.7]
            }
        }";

        float temp = weatherService.ParseTemperatureFromJson(json);

        Assert.AreEqual(28.7f, temp);
    }

    [Test]
    public void ParseTemperature_MissingDaily_ThrowsException()
    {
        string json = @"{
            ""something_else"": {}
        }";

        Assert.Throws<System.Exception>(() =>
        {
            weatherService.ParseTemperatureFromJson(json);
        });
    }

    [Test]
    public void ParseTemperature_MissingTemperatureArray_ThrowsException()
    {
        string json = @"{
            ""daily"": {
                ""time"": [""2024-01-01""]
            }
        }";

        Assert.Throws<System.Exception>(() =>
        {
            weatherService.ParseTemperatureFromJson(json);
        });
    }

    [Test]
    public void ParseTemperature_EmptyTemperatureArray_ThrowsException()
    {
        string json = @"{
            ""daily"": {
                ""temperature_2m_max"": []
            }
        }";

        Assert.Throws<System.Exception>(() =>
        {
            weatherService.ParseTemperatureFromJson(json);
        });
    }
}
