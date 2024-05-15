using AutoMapper;
using Dotnettask.DataContext;
using Dotnettask.DTOs;
using Dotnettask.Model;
using Dotnettask.Services;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;


namespace Dotnettask.Services
{
    public class UserInformationServices : IUserInformationServices
    {
        private readonly CosmosDbContext _context;

        public UserInformationServices(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _context = new CosmosDbContext(cosmosClient, databaseId, containerId);
        }

        public async Task AddUserAsync(UserInformationDTO user)
        {
            await _context.AddItemAsync(user);
        }

        public async Task DeleteUserAsync(string id)
        {
            await _context.DeleteItemAsync<UserInformationDTO>(id);
        }

        public async Task<UserInformationDTO> GetUserAsync(string id)
        {
            return await _context.GetItemAsync<UserInformationDTO>(id);
        }

        public async Task<IEnumerable<UserInformationDTO>> GetUsersAsync(string queryString)
        {
            return await _context.GetItemsAsync<UserInformationDTO>();
        }

        public async Task UpdateUserAsync(string id, UserInformationDTO user)
        {
            await _context.UpdateItemAsync(id, user);
        }
    }

}
