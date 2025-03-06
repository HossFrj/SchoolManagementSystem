namespace SMSystem.Infra.Data.Sql.Queries.Students
{
    public partial class Student
    {
        public int Id { get; set; }
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public int SSN { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? ModifiedByUserId { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public Guid BusinessId { get; set; }
    }
}
