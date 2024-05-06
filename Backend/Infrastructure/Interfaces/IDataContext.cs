using Domain.Common;
using Domain.User;
using Domain.Admin;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Interfaces
{
	public interface IDataContext
	{
		public DbSet<Admin> Admin { get; set; }	
		public DbSet<Complaint> Complaint { get; set; }
		public DbSet<Provider> Provider { get; set; }
		public DbSet<User> User { get; set; }
		public DbSet<Discount> Discount { get; set; }
		public DbSet<Ticket> Ticket { get; set; }	
		public DbSet<Connection> Connection { get; set; }
	}
}