using SimpleForumApp.API.Extensions;
using SimpleForumApp.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureDIContainer();
builder.Services.ConfigurePackages();
builder.Services.AddEndPointExecuitonTimeCalculationFilterToEndPoints();

var app = builder.Build();

await builder.Services.GenerateEndPoints();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.AddGlobalExceptionHandler();

app.Run();
