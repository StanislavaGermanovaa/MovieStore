using Mapster;
using MovieStore.BL;
using MovieStore.DL;
using Serilog.Sinks.SystemConsole.Themes;
using Serilog;
using MovieStore.HealthChecks;
using FluentValidation.AspNetCore;
using FluentValidation;
using MovieStoreB.Validators;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
              .Enrich.FromLogContext()
              .WriteTo.Console(theme:
                  AnsiConsoleTheme.Code)
              .CreateLogger();

builder.Logging.AddSerilog(logger);



// Add services to the container.
builder.Services
             .RegisterRepositories()
             .RegisterServices();

builder.Services.AddMapster();

builder.Services.AddValidatorsFromAssemblyContaining<TestRequestValidator>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks()
    .AddCheck<SampleHealthCheck>("Sample");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthz");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

