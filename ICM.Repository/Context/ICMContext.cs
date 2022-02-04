using Microsoft.EntityFrameworkCore;

namespace ICM.Repository.Context
{
    public class ICMContext : DbContext
    {
        public ICMContext(DbContextOptions<ICMContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ICMContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ILoggerFactory logger = LoggerFactory.Create(c => c.AddConsole());
            //optionsBuilder.UseLoggerFactory(logger);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
