using Dotnettask.Services;
using Microsoft.Azure.Cosmos;

namespace Dotnettask.DataContext
{
    public class CosmosDbContextBase
    {
        protected readonly Container _container;

        public CosmosDbContextBase(CosmosClient cosmosClient, string databaseId, string containerId)
        {
            _container = cosmosClient.GetContainer(databaseId, containerId);
        }

        public async Task AddItemAsync<T>(T item) where T : ICosmosEntity
        {
            await _container.CreateItemAsync<T>(item, new PartitionKey(item.Id));
        }

        public async Task DeleteItemAsync<T>(string id) where T : ICosmosEntity
        {
            await _container.DeleteItemAsync<T>(id, new PartitionKey(id));
        }

        public async Task<T> GetItemAsync<T>(string id) where T : ICosmosEntity
        {
            try
            {
                ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return default(T);
            }
        }


        public async Task<IEnumerable<T>> GetItemsAsync<T>() where T : ICosmosEntity
        {
            var query = _container.GetItemQueryIterator<T>();
            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();
                results.AddRange(response.ToList());
            }
            return results;
        }

        public async Task UpdateItemAsync<T>(string id, T item) where T : ICosmosEntity
        {
            try
            {
                await _container.ReplaceItemAsync<T>(item, id, new PartitionKey(id));
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // Handle or throw
            }
        }
    }

}