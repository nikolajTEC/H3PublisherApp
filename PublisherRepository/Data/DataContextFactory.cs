using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace PublisherRepository.Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            // Use the same connection string as in your OnConfiguring method
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=H3Publisher;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new DataContext(optionsBuilder.Options);
        }
    }
}