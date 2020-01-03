using Microsoft.EntityFrameworkCore;
using RefitSdkDemo.Api.Domain;

namespace RefitSdkDemo.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}
