using LootLoOnline_FunctionApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LootLoOnline_FunctionApp
{
    public class LootLoOnlineDbContext : DbContext
    {
        //public IMemoryCache MemoryCache { get; }
        //private IConfiguration configuration;

        //public LootLoOnlineDbContext(IConfiguration config, IMemoryCache memoryCache)
        //{
        //    configuration = config;
        //    MemoryCache = memoryCache;
        //}

        public LootLoOnlineDbContext()
        {

        }

        public LootLoOnlineDbContext(DbContextOptions<LootLoOnlineDbContext> options)
       : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-K9JI0JL; Initial Catalog=LootLoOnlineDatabase; User id=sa;Password=rajib;");
            }
        }

        public DbSet<OfferProduct> OfferProducts { get; set; }
        public DbSet<DealsOfTheDay> DealsOfTheDays { get; set; }
        public DbSet<Log> Logs { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //}


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OfferProduct>(entity =>
        //    {
        //        entity.Property(e => e.productId)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        //entity.Property(e => e.LastName)
        //        //    .IsRequired()
        //        //    .HasMaxLength(50);
        //    });

        //    modelBuilder.Entity<Log>(entity =>
        //    {
        //        entity.Property(e => e.Id)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //        entity.Property(e => e.Thread)
        //            .IsRequired()
        //            .HasMaxLength(50);

        //       // entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
