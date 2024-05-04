using Domain.User;
using Domain.Common;
using Domain.Admin;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;
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
    public DomainDBContext() { }
    public DomainDBContext(DbContextOptions<DomainDBContext> options) : base(options) {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(k => k.ID);
        });

        modelBuilder.Entity<Complaint>(entity =>
        {
            entity.HasKey(k => k.ID);
        });
        modelBuilder.Entity<Complaint>()
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(c => c.ComplainantID);

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(k => k.ID);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(k => k.ID);

            entity.HasMany<UserDiscount>()
                  .WithOne()
                  .HasForeignKey(ud => ud.UserID);

            entity.Property(u => u.BirthDate)
                  .HasColumnType("datetime");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(k => k.ID);

            entity.HasMany<UserDiscount>()
                  .WithOne()
                  .HasForeignKey(ud => ud.DiscountID);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(k => k.ID);
        });
        modelBuilder.Entity<Ticket>()
        .HasOne<User>()
        .WithMany()
        .HasForeignKey(t => t.OwnerID);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
