using Dotnettask.DTOs;

namespace Dotnettask.Services
{
    public interface IChoiceQuestionService
    {
        Task AddChoiceQuestionAsync(ChoiceQuestionDto choiceQuestion);
        Task DeleteChoiceQuestionAsync(string id);
        Task<ChoiceQuestionDto> GetChoiceQuestionAsync(string id);
        Task<IEnumerable<ChoiceQuestionDto>> GetChoiceQuestionsAsync(string queryString);
        Task UpdateChoiceQuestionAsync(string id, ChoiceQuestionDto choiceQuestion);
    }

}
