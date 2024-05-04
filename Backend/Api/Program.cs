using Microsoft.EntityFrameworkCore;
using Infrastructure.DataRepositories;
using Infrastructure.FakeDataRepositories;
using Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DatabaseService>();
builder.Services.AddSingleton<AdminService>();
builder.Services.AddSingleton<IComplaintService, ComplaintService>();
builder.Services.AddSingleton<PaymentService>();
builder.Services.AddSingleton<ProviderService>();
builder.Services.AddSingleton<RankingService>();
builder.Services.AddSingleton<StatisticsService>();
builder.Services.AddSingleton<TicketService>();
builder.Services.AddSingleton<UserService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();