using Dotnettask.DTOs;
using Dotnettask.Services;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Dotnettask.Model
{
    public class ProgramInformation: ICosmosEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "programId")]
        public string ProgramId { get; set; }

        [JsonProperty(PropertyName = "programTitle")]
        public string ProgramTitle { get; set; }

        [JsonProperty(PropertyName = "programDescription")]
        public string ProgramDescription { get; set; }

        [JsonProperty(PropertyName = "dateAdded")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        [JsonProperty(PropertyName = "userInformation")]
        public List<UserInformationDTO> UserInformation { get; set; }
    }

}
