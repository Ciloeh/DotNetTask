using Dotnettask.DTOs;

namespace Dotnettask.Services
{
    public interface IUserInformationServices
    {
        Task AddUserAsync(UserInformationDTO user);
        Task DeleteUserAsync(string id);
        Task<UserInformationDTO> GetUserAsync(string id);
        Task<IEnumerable<UserInformationDTO>> GetUsersAsync(string queryString);
        Task UpdateUserAsync(string id, UserInformationDTO user);
    }
 


}
