namespace CodeJobs.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Bio { get; set; }
        public string JobTitle { get; set; }
        public string Skills { get; set; }
        public int? ExperienceYears { get; set; }
        public string EmploymentType { get; set; }
        public string PreferredLocation { get; set; }
        public string LinkedInProfile { get; set; }
    }
}