using AutoMapper;
using Dotnettask.DataContext;
using Dotnettask.DTOs;
using Dotnettask.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace Dotnettask.Services
{
    public class ProgramService : IProgramService
    {
        private readonly CosmosDbContext _context;

        public ProgramService(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _context = new CosmosDbContext(cosmosClient, databaseId, containerId);
        }

        public async Task AddProgramAsync(ProgramInformationDTO program)
        {
            await _context.AddItemAsync(program);
        }

        public async Task DeleteProgramAsync(string id)
        {
            await _context.DeleteItemAsync<ProgramInformationDTO>(id);
        }

        public async Task<ProgramInformationDTO> GetProgramAsync(string id)
        {
            return await _context.GetItemAsync<ProgramInformationDTO>(id);
        }

        public async Task<IEnumerable<ProgramInformationDTO>> GetProgramsAsync(string queryString)
        {
            return await _context.GetItemsAsync<ProgramInformationDTO>();
        }

        public async Task UpdateProgramAsync(string id, ProgramInformationDTO program)
        {
            await _context.UpdateItemAsync(id, program);
        }
    }
}
