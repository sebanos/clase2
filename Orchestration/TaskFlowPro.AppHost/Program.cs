var builder = DistributedApplication.CreateBuilder(args);

// Add API project (connects to external SQL Server)
var apiService = builder.AddProject<Projects.TaskFlowPro_Api>("taskflowpro-api");

// Add Blazor Web project
var webApp = builder.AddProject<Projects.TaskFlowPro_Web>("taskflowpro-web")
    .WithReference(apiService);

builder.Build().Run();
