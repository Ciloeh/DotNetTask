using Dotnettask.DTOs;
using Microsoft.Azure.Cosmos;

namespace Dotnettask.Services
{
    public interface IProgramService
    {
        Task AddProgramAsync(ProgramInformationDTO program);
        Task DeleteProgramAsync(string id);
        Task<ProgramInformationDTO> GetProgramAsync(string id);
        Task<IEnumerable<ProgramInformationDTO>> GetProgramsAsync(string queryString);
        Task UpdateProgramAsync(string id, ProgramInformationDTO program);
    }

}
