using Mapster;
using MovieStore.BL;
using MovieStore.DL;
using Serilog.Sinks.SystemConsole.Themes;
using Serilog;

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

