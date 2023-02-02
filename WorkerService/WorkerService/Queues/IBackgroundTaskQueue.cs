using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WorkerService.Queues
{
    public interface IBackgroundTaskQueue<T>
    {
        ValueTask AddQueue(T workItem);

        ValueTask<T> DeQueue(CancellationToken cancellationToken);
    }

    public class NamesQueue : IBackgroundTaskQueue<string>
    {
        private readonly Channel<string> queue;

        public NamesQueue(IConfiguration configuration)
        {
            int.TryParse(configuration["QueueCapacity"], out int capacity);

            BoundedChannelOptions options = new(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };

            queue = Channel.CreateBounded<string>(options);
        }

        public async ValueTask AddQueue(string workItem)
        {
            ArgumentNullException.ThrowIfNull(workItem);

            await queue.Writer.WriteAsync(workItem);
        }

        public ValueTask<string> DeQueue(CancellationToken cancellationToken)
        {
            var workItem = queue.Reader.ReadAsync(cancellationToken);
            return workItem;
        }
    }
}
