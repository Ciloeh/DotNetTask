using Dotnettask.DataContext;
using Dotnettask.DTOs;
using Microsoft.Azure.Cosmos;

namespace Dotnettask.Services
{
    public class ChoiceQuestionService : IChoiceQuestionService
    {
        private readonly CosmosDbContext _context;

        public ChoiceQuestionService(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _context = new CosmosDbContext(cosmosClient, databaseId, containerId);
        }

        public async Task AddChoiceQuestionAsync(ChoiceQuestionDto choiceQuestion)
        {
            await _context.AddItemAsync(choiceQuestion);
        }

        public async Task DeleteChoiceQuestionAsync(string id)
        {
            await _context.DeleteItemAsync<ChoiceQuestionDto>(id);
        }

        public async Task<ChoiceQuestionDto> GetChoiceQuestionAsync(string id)
        {
            return await _context.GetItemAsync<ChoiceQuestionDto>(id);
        }

        public async Task<IEnumerable<ChoiceQuestionDto>> GetChoiceQuestionsAsync(string queryString)
        {
            return await _context.GetItemsAsync<ChoiceQuestionDto>();
        }

        public async Task UpdateChoiceQuestionAsync(string id, ChoiceQuestionDto choiceQuestion)
        {
            await _context.UpdateItemAsync(id, choiceQuestion);
        }
    }

}
