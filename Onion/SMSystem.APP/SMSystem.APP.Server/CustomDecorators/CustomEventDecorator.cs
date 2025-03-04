using Zamin.Core.ApplicationServices.Events;

namespace SMSystem.APP.Server.CustomDecorators;

public class CustomEventDecorator : EventDispatcherDecorator
{
    public override int Order => 0;

    public override async Task PublishDomainEventAsync<TDomainEvent>(TDomainEvent @event)
    {
        await _eventDispatcher.PublishDomainEventAsync(@event);
    }
}