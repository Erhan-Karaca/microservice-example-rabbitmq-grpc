using WorkerService.Queues;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IBackgroundTaskQueue<string> _queue;

        public Worker(ILogger<Worker> logger, IBackgroundTaskQueue<string> queue)
        {
            _logger = logger;
            _queue = queue;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var name = await _queue.DeQueue(stoppingToken);

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}