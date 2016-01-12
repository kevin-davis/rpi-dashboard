using System;
using ForecastIO;
using System.Configuration;
using System.Net;

/// <summary>
/// Summary description for Forecast
/// </summary>
public static class ForecastIOInterface
{
    private static string ApiKey
    {
        get
        {
            return ConfigurationManager.AppSettings["ForecastIOApiKey"];
        }
    }
    public static Forecast GetForecast()
    {
        try {
            var excludeBlocks = new Exclude[]
            {
            Exclude.alerts,
            Exclude.minutely,
            Exclude.hourly,
            //Exclude.daily,
            Exclude.flags
            };

            var request = new ForecastIORequest(ApiKey, 46.280613f, -119.340984f, DateTime.Now, Unit.us, null, excludeBlocks);
            var forecast = request.Get();
            return new Forecast(forecast.daily.data[0].apparentTemperatureMax,
                forecast.daily.data[0].apparentTemperatureMin,
                forecast.currently.temperature,
                forecast.currently.summary,
                forecast.currently.icon);
        }
        catch (WebException ex)
        {
            return new Forecast(0, 0, 0, "The weather man called in sick.", "broken");
        }
    }
}

