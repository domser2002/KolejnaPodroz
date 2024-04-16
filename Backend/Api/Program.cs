using Api;
using Api.Services.Implementations;
using Api.Services.Interfaces;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<DomainDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<AccountService>();
builder.Services.AddSingleton<AdminService>();
builder.Services.AddSingleton<IComplaintService, ComplaintService>();
builder.Services.AddSingleton<DatabaseService>();
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