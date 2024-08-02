using KC.API.Model;

namespace KC.API.DTO
{
    public class LabourDto
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; }
        public List<Skill> Skills { get; set; }

    }
}       