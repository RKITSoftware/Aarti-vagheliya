using Dependancy_Injection.Model;
using Microsoft.EntityFrameworkCore;

namespace Dependancy_Injection.Data
{
    /// <summary>
    /// Database context class for interacting with the database.
    /// </summary>
    public class DBContextClass : DbContext
    {
        /// <summary>
        /// Constructor for initializing the database context.
        /// </summary>
        /// <param name="options">The options for configuring the context.</param>
        public DBContextClass(DbContextOptions<DBContextClass> options) : base(options)
        {
        }

        /// <summary>
        /// DbSet property representing the 'Countries' table in the database.
        /// </summary>
        public DbSet<Country> Countries { get; set; } 

        /// <summary>
        /// Method for configuring the model for the database context.
        /// </summary>
        /// <param name="modelBuilder">The model builder instance.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasKey(c => c.t01f01); // Assuming 'Id' is the primary key property
        }
    }
}
