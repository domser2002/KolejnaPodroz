using Api.FakeData;
using Domain.Models;
using Logic.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ConnectionService>();
builder.Services.AddSingleton<JourneyService>();
builder.Services.AddSingleton<StationService>();
builder.Services.AddSingleton<TicketService>();
builder.Services.AddSingleton<TrainService>();
builder.Services.AddSingleton<FakeDataGenerator>();

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
