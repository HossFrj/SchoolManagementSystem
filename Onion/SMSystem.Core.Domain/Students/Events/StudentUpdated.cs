using Zamin.Core.Domain.Events;

namespace SMSystem.Core.Domain.Students.Events;

public record StudentUpdated(Guid BusinessId,
    int ssn,
    string firstName,
    string lastName) : IDomainEvent;
