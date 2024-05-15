using Dotnettask.DTOs;

namespace Dotnettask.Services
{
    public interface IUserQuestionServices
    {
        Task AddUserQuestionAsync(UserQuestionDto userQuestion);
        Task DeleteUserQuestionAsync(string id);
        Task<UserQuestionDto> GetUserQuestionAsync(string id);
        Task<IEnumerable<UserQuestionDto>> GetUserQuestionsAsync(string queryString);
        Task UpdateUserQuestionAsync(string id, UserQuestionDto userQuestion);
    }

}
