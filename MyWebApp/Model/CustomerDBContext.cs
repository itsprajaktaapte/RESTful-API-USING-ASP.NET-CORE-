
using Microsoft.EntityFrameworkCore;
namespace MyWebApp.Model
{
    public class CustomerDBContext : DbContext
    {
        // this class connects with database

        // base constructor 
        public CustomerDBContext(DbContextOptions<CustomerDBContext> options)
            : base(options)
        {

        }
        // model name will go here 
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }

       
    }
}
