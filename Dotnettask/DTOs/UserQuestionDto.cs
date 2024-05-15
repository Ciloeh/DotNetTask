using Dotnettask.Constants;
using Dotnettask.Model;
using Dotnettask.Services;

namespace Dotnettask.DTOs
{
    public class UserQuestionDto: ICosmosEntity
    {
        public string Id { get; set; }
        public QuestionType QuestionType { get; set; }
        public List<ChoiceQuestionDto> ChoiceQuestions { get; set; }
        public int MaxChoiceAllowed { get; set; }
        public bool EnableOtherOption { get; set; }
        public string Question { get; set; }

    }

}
