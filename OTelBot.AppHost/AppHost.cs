var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.OTelBot_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.Build().Run();
