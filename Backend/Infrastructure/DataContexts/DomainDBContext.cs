using Domain.User;
using Domain.Common;
using Domain.Admin;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
namespace Infrastructure.DataContexts;

public partial class DomainDBContext : DbContext, IDataContext
{
    public virtual DbSet<Admin> Admin { get; set; }
    public virtual DbSet<Complaint> Complaint { get; set; }
    public virtual DbSet<Provider> Provider { get; set; }
    public virtual DbSet<Ticket> Ticket { get; set; }
    public virtual DbSet<User> User { get; set; }
    public virtual DbSet<Discount> Discount { get; set; }
    public virtual DbSet<UserDiscount> UserDiscount { get; set; }
    public virtual DbSet<Connection> Connection { get; set; }
    public virtual DbSet<Station> Station { get; set; }
    public virtual DbSet<StopDetails> StopDetails { get; set; }
    public virtual DbSet<Statistics> Statistics { get; set; }

    public virtual DbSet<StatisticCategory> StatisticCategory { get; set; }
    public DomainDBContext() { }
    public DomainDBContext(DbContextOptions<DomainDBContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
            entity.HasOne<User>().WithMany().HasForeignKey(c => c.ComplainantID);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
            entity.HasOne<User>().WithMany().HasForeignKey(t => t.OwnerID);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();

            entity.HasMany<UserDiscount>()
                  .WithOne()
                  .HasForeignKey(ud => ud.UserID);

            entity.Property(u => u.BirthDate)
                  .HasColumnType("datetime");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();

            entity.HasMany<UserDiscount>()
                  .WithOne()
                  .HasForeignKey(ud => ud.DiscountID);
        });

        modelBuilder.Entity<Connection>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
            entity.HasOne<Provider>().WithMany().HasForeignKey(c => c.ProviderID);
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<StopDetails>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
            entity.HasOne<Station>().WithMany().HasForeignKey(sd => sd.StationID);
            entity.HasOne<Connection>().WithMany().HasForeignKey(sd => sd.ConnectionID);
            entity.Property("ArrivalTime").HasColumnType("datetime");
            entity.Property("DepartureTime").HasColumnType("datetime");
        });

        modelBuilder.Entity<Statistics>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
            entity.HasOne<User>().WithMany().HasForeignKey(st => st.UserID);
            entity.HasOne<StatisticCategory>().WithMany().HasForeignKey(st => st.CategoryID);
        });

        modelBuilder.Entity<StatisticCategory>(entity =>
        {
            entity.HasKey(k => k.ID);
            entity.Property(k => k.ID).ValueGeneratedOnAdd();
        });
        
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
