using System.Text.Json.Serialization;
using KC.API.DTO;
using KC.API.Model;
using MediatR;

namespace KC.API.Application.Commands
{
    public class UpsertLabourCommand : IRequest<int>
    {
        [JsonIgnore]
        public int? Id { get; set; }
        public string FullName { get; init; } = string.Empty;
        public int Age { get; init; }
        public string? MobileNumber { get; init; }
        public string? Email { get; init; }
        public List<Skill> Skills { get; init; } = [];

        public void SetIds(int? id)
        {

            Id = id;
        }
    }


}
