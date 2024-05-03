using Logic.Services.Implementations;
using Logic.Services.Interfaces;
using Infrastructure.DataContexts;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataRepositories;
using Infrastructure.FakeDataRepositories;
using Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton(serviceProvider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<DomainDBContext>();
    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    return new DomainDBContext(optionsBuilder.Options);
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IDataRepository, FakeDataRepository>();
builder.Services.AddSingleton<DatabaseService>();
builder.Services.AddSingleton<AdminService>();
builder.Services.AddSingleton<IComplaintService, ComplaintService>();
builder.Services.AddSingleton<PaymentService>();
builder.Services.AddSingleton<ProviderService>();

builder.Services.AddSingleton<StatisticsService>();
builder.Services.AddSingleton<TicketService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<IConnectionService, ConnectionService>();

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