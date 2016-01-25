using System.Data.Entity;

namespace GridComponent.Models.DataAccess
{
    public class EntitiesContext<T> : DbContext where T : class
    {
        public EntitiesContext() : base(SqlServerConfiguration.ConnectionString) { }

        public DbSet<T> Entities { get; set; }
    }
}