using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Admin;
using Domain.User;

namespace Domain.Common
{
    public partial class DomainDBContext : DbContext
    {
        public DomainDBContext() { }
        public DomainDBContext(DbContextOptions
        <DomainDBContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Admin.Admin> Admin { get; set; }
        public virtual DbSet<Complaint> Complaint { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<User.User> AccountInfo { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<User.User> User { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin.Admin>(entity => {
                entity.HasKey(k => k.ID);
            });
            modelBuilder.Entity<Complaint>(entity => {
                entity.HasKey(k => k.ID);
            });
            modelBuilder.Entity<Provider>(entity => {
                entity.HasKey(k => k.ID);
            });
            modelBuilder.Entity<User.User>()
            .HasMany(e => e.Discounts)
            .WithMany(e => e.Users);
            modelBuilder.Entity<Ticket>(entity => {
                entity.HasKey(k => k.ID);
            });
            modelBuilder.Entity<User.User>(entity => {
                entity.HasKey(k => k.ID);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
