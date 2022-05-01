using Microsoft.EntityFrameworkCore;

namespace InquiryPlate.Data
{

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Sets
        public DbSet<Plate> Plates { get; set; }
        #endregion


        //public virtual DbCommand CreateCommand()
        //{
        //    return Database.GetDbConnection().CreateCommand();
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DBInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            DBInitializer initializer = new DBInitializer();
            initializer.Seed(context);
        }

        public void Seed(AppDbContext context)
        {
            context.Database.EnsureCreated();

            var infractions = new List<Infraction>();
            infractions.Add(new Infraction
            {
                Price = "10000",
                DateTime = "29/1/1401",
                Description = "پارک ممنوع"
            });
            infractions.Add(new Infraction
            {
                Price = "20000",
                DateTime = "20/1/1401",
                Description = "تلفن همراه"
            });
            var plate = new Plate
            {
                LicensePlate = "1234567",
                Infractions = infractions
            };

            context.Plates.Add(plate);
            context.SaveChanges();
        }
    }
}



