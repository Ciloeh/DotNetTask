using Dotnettask.DTOs;
using Dotnettask.Model;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;


namespace Dotnettask.DataContext
{
    public class CosmosDbContext : CosmosDbContextBase
    {
        public string DatabaseId { get; }
        public string ContainerId { get; }

        public CosmosDbContext(CosmosClient cosmosClient, string databaseId, string containerId)
            : base(cosmosClient, databaseId, containerId)
        {
            DatabaseId = databaseId;
            ContainerId = containerId;
        }
    }


}
