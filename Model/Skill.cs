using KC.API.Common;
using System.ComponentModel.DataAnnotations;

namespace KC.API.Model
{
    public class Skill
    {
         public string SkillName { get; set; } = string.Empty;
        public int Experience { get; set; }
    }
}