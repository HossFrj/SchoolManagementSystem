using System.ComponentModel.DataAnnotations;
using Zamin.Core.Domain.Entities;

namespace SMSystem.Core.Domain.Students.Entites
{
    public class Student : AggregateRoot<int>
    {
        //[Key]
        //public Guid StudentID { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(20)]
        public string? SSN { get; set; }

        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }

    }
}
