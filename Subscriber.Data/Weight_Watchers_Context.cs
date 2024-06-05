using Microsoft.EntityFrameworkCore;
using Subscriber_Data.Entities;

namespace Subscriber_Data
{
    public class Weight_Watchers_Context : DbContext
    {
        public Weight_Watchers_Context(DbContextOptions<Weight_Watchers_Context> options) : base(options)
        {
        }
        public DbSet<Card_Table> Card_Table { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; }
        

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        // כאן מוסיפים את ההגדרות הנדרשות ל־DbContextOptions
        //        optionsBuilder.UseSqlServer("connection_string_here", b => b.MigrationsAssembly("FinalProject"));
        //    }
        //}
    }
}
