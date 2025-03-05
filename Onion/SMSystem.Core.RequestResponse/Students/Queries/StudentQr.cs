namespace SMSystem.Core.RequestResponse.Students.Queries
{
    public class StudentQr
    {
        public int Id { get; set; }
        public int SSN { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}
