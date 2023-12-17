using Contracts;
using MassTransit;

namespace Lab6_Gods.Consumers;

public class ReadyPlayersConsumer : IConsumer<OkPlayer>
{
    public Task Consume(ConsumeContext<OkPlayer> context)
    {
        lock (ReadyPlayerControl.LockObject)
        {
            ReadyPlayerControl.CountReady += 1;
            if (ReadyPlayerControl.CountReady != 2) return Task.CompletedTask;
            context.Publish(new SenderCompleted());
            ReadyPlayerControl.CountReady = 0;
        }
        return Task.CompletedTask;
    }
}