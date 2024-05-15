using AutoMapper;
using Dotnettask.DataContext;
using Dotnettask.DTOs;
using Dotnettask.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;

namespace Dotnettask.Services
{

    public class UserQuestionServices : IUserQuestionServices
    {
        private readonly CosmosDbContext _context;

        public UserQuestionServices(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _context = new CosmosDbContext(cosmosClient, databaseId, containerId);
        }

        public async Task AddUserQuestionAsync(UserQuestionDto userQuestion)
        {
            await _context.AddItemAsync(userQuestion);
        }

        public async Task DeleteUserQuestionAsync(string id)
        {
            await _context.DeleteItemAsync<UserQuestionDto>(id);
        }

        public async Task<UserQuestionDto> GetUserQuestionAsync(string id)
        {
            return await _context.GetItemAsync<UserQuestionDto>(id);
        }

        public async Task<IEnumerable<UserQuestionDto>> GetUserQuestionsAsync(string queryString)
        {
            return await _context.GetItemsAsync<UserQuestionDto>();
        }

        public async Task UpdateUserQuestionAsync(string id, UserQuestionDto userQuestion)
        {
            await _context.UpdateItemAsync(id, userQuestion);
        }
    }

}
