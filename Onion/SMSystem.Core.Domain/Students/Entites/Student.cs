using Microsoft.EntityFrameworkCore;
using SMSystem.Core.Domain.Students.Events;
using System.ComponentModel.DataAnnotations;
using Zamin.Core.Domain.Entities;

namespace SMSystem.Core.Domain.Students.Entites
{
    [Index(nameof(SSN), IsUnique = true)]
    public class Student : AggregateRoot<int>
    {

        #region Properties
        [Required]
        public string SSN { get; set; } = string.Empty;
        [Required]

        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        #endregion

        #region Constructors
        private Student()
        {

        }
        public Student(string ssn, string firstName, string lastName)
        {
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;
            AddEvent(new StudentCreated(BusinessId.Value, ssn, firstName, lastName));
        }
        #endregion

        #region Commands
        public static Student Create(string ssn, string firstName, string lastName) => new(ssn, firstName, lastName);

        public void Update(string ssn, string firstName, string lastName)
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
