using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechCafe.Repository.Entities;

namespace TechCafe.Repository
{
    /**
     * Do not implement Repository and UoW pattern
     * Follow here : https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/advanced?view=aspnetcore-2.1
     **/
    public class TechCafeDbContext : DbContext
    {
        public TechCafeDbContext(DbContextOptions<TechCafeDbContext> options) : base(options)
        {          
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
