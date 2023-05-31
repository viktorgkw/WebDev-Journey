using ExceptionHandler.Exceptions;
using ExceptionHandler.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/firstplayer", () =>
{
    throw new PlayerNotFoundException("I was not found.", new Exception());
});

app.MapGet("/secondplayer", () =>
{
    throw new ArgumentException("What is secondplayer?.", new Exception());
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();