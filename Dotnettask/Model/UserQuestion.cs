using Dotnettask.Constants;
using Dotnettask.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dotnettask.Model
{
    public class UserQuestion: ICosmosEntity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "questionType")]
        public QuestionType QuestionType { get; set; }

        [JsonProperty(PropertyName = "choiceQuestions")]
        public List<ChoiceQuestion> ChoiceQuestions { get; set; }

        [JsonProperty(PropertyName = "maxChoiceAllowed")]
        public int MaxChoiceAllowed { get; set; }

        [JsonProperty(PropertyName = "enableOtherOption")]
        public bool EnableOtherOption { get; set; }

        [JsonProperty(PropertyName = "question")]
        public string Question { get; set; }

        [JsonProperty(PropertyName = "userId")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "userInformation")]
        public UserInformation UserInformation { get; set; }

        [JsonProperty(PropertyName = "dateAdded")]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;
    }

}
