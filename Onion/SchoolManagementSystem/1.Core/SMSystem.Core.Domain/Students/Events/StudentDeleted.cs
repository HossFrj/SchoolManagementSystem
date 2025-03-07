using Zamin.Core.Domain.Events;

namespace SMSystem.Core.Domain.Students.Events;

public record StudentDeleted(Guid BusinessId) : IDomainEvent;
