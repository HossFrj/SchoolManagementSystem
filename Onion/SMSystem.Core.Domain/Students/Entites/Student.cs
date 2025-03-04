using SMSystem.Core.Domain.Students.Events;
using Zamin.Core.Domain.Entities;
using Zamin.Core.Domain.Exceptions;

namespace SMSystem.Core.Domain.Students.Entites
{
    public class Student : AggregateRoot<int>
    {
        #region Properties
        public int SSN { get; set; }

        public string? FirstName { get; set; }

        //[Required]
        //[StringLength(50)]
        public string? LastName { get; set; }
        #endregion

        #region Constructors
        private Student()
        {

        }
        public Student(int ssn, string firstName, string lastName)
        {
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;
            AddEvent(new StudentCreated(BusinessId.Value, ssn, firstName, lastName));
        }
        #endregion

        #region Commands
        public static Student Create(int ssn, string firstName, string lastName) => new(ssn, firstName, lastName);

        public void Update(int ssn, string firstName, string lastName)
        {
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;

            AddEvent(new StudentUpdated(BusinessId.Value, ssn, firstName, lastName));
        }
        public void Delete()
        {
            AddEvent(new StudentDeleted(BusinessId.Value));
        }

        #endregion

    }
}
