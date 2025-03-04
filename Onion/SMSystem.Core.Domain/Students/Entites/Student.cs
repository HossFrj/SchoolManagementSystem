namespace SMSystem.Core.Domain.Students.Entites
{
    public class Student : AggregateRoot<int>
    {
        #region Properties
        [Required]
        [StringLength(20)]
        public string? SSN { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        #endregion

        #region Constructors
        private Student()
        {

        }
        public Student(SNN ssn, FirstName firstName, LastName lastName)
        {
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;
            AddEvent(new BlogCreated(BusinessId.Value, Title.Value, Description.Value));
        }
        #endregion

        #region Commands

        #endregion

    }
}
