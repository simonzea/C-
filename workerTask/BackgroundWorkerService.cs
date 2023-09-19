
namespace Namespace;
public class BackgroundWorkerService : BackgroundService
{
    readonly ILogger<BackgroundWorkerService> _logger;
    public BackgroundWorkerService(ILogger<BackgroundWorkerService> logger) {
        _logger = logger;
    }

    
    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested){
            _logger.LogInformation("Worker Runing at: {time}", DateTimeOffset.Now );
            _logger.LogInformation("Worker Runing at: {time}", DateTimeOffset.Now );
            _logger.LogInformation("Worker Runing at: {time}", DateTimeOffset.Now );
            await Task.Delay(30000, stoppingToken);
        }
    }
}
