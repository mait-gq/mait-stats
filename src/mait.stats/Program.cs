
using Services;
using Dto;
using Controllers;
using Microsoft.Extensions.Http.Resilience;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
    options.ColorBehavior = Microsoft.Extensions.Logging.Console.LoggerColorBehavior.Enabled;
});

builder.Services.AddHealthChecks();

builder.Services.AddHttpClient<SerieServiceClient>(client =>
{
    var options = builder.Configuration.GetSection(nameof(ClientsOptions)).Get<ClientsOptions>();
    client.BaseAddress = new Uri(options!.Series);
})
.AddStandardResilienceHandler();

builder.Services.AddHttpClient<DocumentServiceClient>(client =>
{
    var options = builder.Configuration.GetSection(nameof(ClientsOptions)).Get<ClientsOptions>();
    client.BaseAddress = new Uri(options!.Documents);
})
.AddStandardResilienceHandler(o =>
{
    o.TotalRequestTimeout.Timeout = TimeSpan.FromSeconds(90);
    o.AttemptTimeout.Timeout = TimeSpan.FromSeconds(60);
    o.Retry.MaxRetryAttempts = 1;
});

builder.Services.AddHttpClient<FuncionarioServiceClient>(client =>
{
    var options = builder.Configuration.GetSection(nameof(ClientsOptions)).Get<ClientsOptions>();
    client.BaseAddress = new Uri(options!.Funcionario);
})
.AddStandardResilienceHandler();


builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new()
    {
        Title = "Stat Service API",
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();

if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Funcionario Series API v1");
        options.RoutePrefix = "swagger"; // disponible en /swagger
    });
}

var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("✅ Aplicación iniciada");

app.MapHealthChecks("/healthz/live", new HealthCheckOptions { Predicate = _ => false });
app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
{
    Predicate = hc => hc.Tags.Contains("ready"),
});
app.MapHealthChecks("/healthz", new HealthCheckOptions
{
    Predicate = hc => hc.Tags.Contains("ready"),
});

app.Run();

public partial class Program { } // <--- Esto es clave para que WebApplicationFactory lo encuentre
