using Dotnettask.Services;

namespace Dotnettask.DTOs
{
    public class ChoiceQuestionDto: ICosmosEntity
    {
        public string Id { get; set; }
        public string Choice { get; set; }
        public DateTime dateadded { get; set; } 
    }
}
