using Azure.Core;
using KC.API.Common;

namespace KC.API.Model
{
    public class Labour : sqlEntity
    {
         public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? MobileNumber { get; set; }

        public string? Email { get; set; }

        public List<Skill>? Skills;

        Labour() {
            Skills = new();
        }
        public Labour(string fullName, int age, string? mobileNumber, string? email, List<Skill> skills) : this() { 
        FullName = fullName;
            Age = age;
            MobileNumber = mobileNumber;
            Email = email;
            Skills = skills;
        }
        public void Update(string fullName, int age, string? mobileNumber, string? email, List<Skill> skills) { 
        FullName = fullName;
            Age = age;
            MobileNumber = mobileNumber;
            Email = email;
            Skills.Clear();
            Skills.AddRange(skills);

        }
    }
}