
namespace Namespace;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using TimeZoneConverter;
public class BackgroundWorkerService : BackgroundService
{
    readonly ILogger<BackgroundWorkerService> _logger;
    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger) {
        _logger = logger;
    }

    
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {

        List<string> cities = new List<string>();

        cities.Add("Bogota");
        cities.Add("Central Time (US & Canada)");
        cities.Add("Buenos Aires");
        cities.Add("Eastern Time (US & Canada)");
        cities.Add("London");

        ReadOnlyCollection<string> readOnlyCities =
            new ReadOnlyCollection<string>(cities);

        foreach( string dinosaur in readOnlyCities )
        {
            Console.WriteLine(dinosaur);
        }

        while(!stoppingToken.IsCancellationRequested){
            DateTime timeUtc = DateTime.UtcNow;
            

            foreach( string city in readOnlyCities )
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById(TZConvert.RailsToWindows(city));
            DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
            _logger.LogInformation("City: {city}", city );
            _logger.LogInformation("TimeZone: {timeZone}", TZConvert.RailsToIana(city) );
            _logger.LogInformation("Time: {time}", cstTime.ToString("yyyy-MM-dd'T'HH:mm:ss.FFFzzz", System.Globalization.CultureInfo.InvariantCulture) );
        }
            
            
            await Task.Delay(30000, stoppingToken);
        }
    }
}
