using Shop11A.Models;
using System.Data.Entity;
using System.Web;

namespace Shop11A.Data
{
    public class DBContext : DbContext
    {
        // Constructor that passes the connection string to the base DbContext class
        public DBContext() 
        {
        }

        // DbSets representing tables in the database
        public DbSet<Product> Products { get; set; }


    }


}
