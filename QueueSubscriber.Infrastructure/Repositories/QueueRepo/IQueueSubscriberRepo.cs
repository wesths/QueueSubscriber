using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueSubscriber.Infrastructure.Repositories.QueueRepo
{
    public interface IQueueSubscriberRepo
    {
        Task RunAsync(CancellationToken cancellationToken);
        Task StopAsync(CancellationToken cancellationToken);
    }
}
