using Zamin.Core.Domain.Events;

namespace SMSystem.Core.Domain.Students.Events;

public record StudentCreated(Guid BusinessId,
    int ssn,
    string firstName,
    string lastName) : IDomainEvent;