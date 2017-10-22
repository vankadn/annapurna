using annapurnaAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Context
{
    public class AnnapurnaContext : DbContext
    {
        public AnnapurnaContext(DbContextOptions<AnnapurnaContext> options) : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }

    public static class AnnapurnaContextFactory
    {
        public static AnnapurnaContext Create(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnnapurnaContext>();
            optionsBuilder.UseMySQL(connectionString);

            //Ensure database creation
            var context = new AnnapurnaContext(optionsBuilder.Options);
            context.Database.EnsureCreated();

            return context;
        }
    }
}
