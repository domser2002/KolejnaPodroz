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


<<<<<<< HEAD
builder.Services.AddSingleton<IDataRepository, FakeDataRepository>();
builder.Services.AddSingleton<DatabaseService>();
=======
builder.Services.AddSingleton<IDataRepository, DataRepository>();
builder.Services.AddSingleton<IDatabaseService, DatabaseService>();
>>>>>>> a74bc51bef6ba1c96400b1969d16eb09f17fb0cc
builder.Services.AddSingleton<IAdminService, AdminService>();
builder.Services.AddSingleton<IComplaintService, ComplaintService>();
builder.Services.AddSingleton<IPaymentService,PaymentService>();
builder.Services.AddSingleton<IProviderService,ProviderService>();
builder.Services.AddSingleton<IStatisticsService,StatisticsService>();
builder.Services.AddSingleton<ITicketService,TicketService>();
builder.Services.AddSingleton<IUserService,UserService>();
builder.Services.AddSingleton<IConnectionService, ConnectionService>();

var app = builder.Build();

app.UseCors(builder => builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader());

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
