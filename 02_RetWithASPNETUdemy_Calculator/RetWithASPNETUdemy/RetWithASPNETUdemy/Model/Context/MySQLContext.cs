using Microsoft.EntityFrameworkCore;

namespace RetWithASPNETUdemy.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<Person> Persons { get; set; }
        public DbSet <Book> Book { get; set; }
    }
}
