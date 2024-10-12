using SimpleForumApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureDIContainer();
builder.Services.ConfigurePackages();
builder.Services.AddEndPointExecuitonTimeCalculationFilterToEndPoints();

var app = builder.Build();

await builder.Services.GenerateEndPoints();
await builder.Services.GenerateClaimBusinessRules();
await builder.Services.CacheAuthInformations();

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.AddGlobalExceptionHandler();

app.Run();
