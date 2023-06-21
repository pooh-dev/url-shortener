namespace UrlShortener.Services;

public class UrlUsageInfoHostedService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    public UrlUsageInfoHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (IServiceScope scope = _serviceProvider.CreateScope())
            {
                var urlUsageInfoHandler = scope.ServiceProvider.GetService<UrlUsageInfoHandler>();
                await urlUsageInfoHandler.Handle();
            }

            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}
