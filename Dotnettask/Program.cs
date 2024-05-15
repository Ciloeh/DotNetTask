using Dotnettask.DataContext;
using Dotnettask.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Bind the configuration values to CosmosDbSettings
var cosmosDbSettings = new CosmosDbSettings();
configuration.GetSection("CosmosDb").Bind(cosmosDbSettings);

// Add services to the container.
// Add CosmosClient using Azure Cosmos DB
builder.Services.AddSingleton((provider) =>
{
    var cosmosClientOptions = new CosmosClientOptions
    {
        ApplicationName = cosmosDbSettings.DatabaseName,
        ConnectionMode = ConnectionMode.Gateway,
    };

    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });

    var cosmosClient = new CosmosClient(cosmosDbSettings.AccountEndpoint, cosmosDbSettings.AccountKey, cosmosClientOptions);

    return cosmosClient;
});

// Add DbContext using Azure Cosmos DB
builder.Services.AddSingleton(sp =>
{
    var cosmosClient = sp.GetRequiredService<CosmosClient>();
    return new CosmosDbContext(cosmosClient, cosmosDbSettings.DatabaseName, "JudeDotNetTask"); // Replace "ContainerName" with your actual container name
});

// Register your services
builder.Services.AddScoped<IProgramService>(sp =>
{
    var cosmosClient = sp.GetRequiredService<CosmosClient>();
    var dbContext = sp.GetRequiredService<CosmosDbContext>();
    return new ProgramService(cosmosClient, dbContext.DatabaseId, dbContext.ContainerId);
});

builder.Services.AddScoped<IUserInformationServices>(sp =>
{
    var cosmosClient = sp.GetRequiredService<CosmosClient>();
    var dbContext = sp.GetRequiredService<CosmosDbContext>();
    return new UserInformationServices(cosmosClient, dbContext.DatabaseId, dbContext.ContainerId);
});

builder.Services.AddScoped<IUserQuestionServices>(sp =>
{
    var cosmosClient = sp.GetRequiredService<CosmosClient>();
    var dbContext = sp.GetRequiredService<CosmosDbContext>();
    return new UserQuestionServices(cosmosClient, dbContext.DatabaseId, dbContext.ContainerId);
});

builder.Services.AddScoped<IChoiceQuestionService>(sp =>
{
    var cosmosClient = sp.GetRequiredService<CosmosClient>();
    var dbContext = sp.GetRequiredService<CosmosDbContext>();
    return new ChoiceQuestionService(cosmosClient, dbContext.DatabaseId, dbContext.ContainerId);
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
