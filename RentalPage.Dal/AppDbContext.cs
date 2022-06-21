using Microsoft.EntityFrameworkCore;
using RentalPage.Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalPage.Dal
{
    public class AppDbContext: DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<RentItem> RentItems => Set<RentItem>();
        public DbSet<RentedItem> RentedItems => Set<RentedItem>();
        public DbSet<User> Users => Set<User>();

        public object RentedItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.UseHiLo("DBSequenceHiLo");
            modelBuilder.HasSequence<int>("DBSequenceHiLo")
                .StartsAt(1000).IncrementsBy(50);

            modelBuilder.Entity<RentedItem>().Property(x => x.Id).UseHiLo("DBSequenceHiLo");
            modelBuilder.Entity<RentItem>().Property(x => x.Id).UseHiLo("DBSequenceHiLo");
            modelBuilder.Entity<User>().Property(x => x.Id).UseHiLo("DBSequenceHiLo");



            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<RentedItem>().HasKey(x => x.Id);
            modelBuilder.Entity<RentItem>().HasKey(x => x.Id);

            modelBuilder.Entity<RentedItem>()
                .HasOne(r => r.RentItem)
                .WithOne(r => r.RentedItem)
                .HasForeignKey<RentedItem>(r => r.RentItemId);

            modelBuilder.Entity<RentedItem>()
                .HasOne(r => r.User) 
                .WithMany(u => u.RentedItems)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<RentItem>()
                .Property(e => e.Category)
                .HasConversion(
                    v => v.ToString(),
                    v => (Category)Enum.Parse(typeof(Category), v)
                );


            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Name = "Sarah Parker" },
                new User { Id = 2, Name = "Michael Corse" },
                new User { Id = 3, Name = "Anna Smith" }
            );

            modelBuilder.Entity<RentItem>().HasData(
                new RentItem

                {
                    Id = 1, 
                    Name = "síléc", 
                    Description = "sielni lehet vele",
                    Price = 500,
                    Available = true,
                    Category = Category.CATEGORY_SKI
                },
                new RentItem
                {
                    Id = 2,
                    Name = "snowboard csizma",
                    Description = "tartja a bokád",
                    Price = 1000,
                    Available = true,
                    Category = Category.CATEGORY_SNOWBOARD
                }, 
                new RentItem
                {
                    Id = 3,
                    Name = "snowboard",
                    Description = "gyors",
                    Price = 2000,
                    Available = true,
                    Category = Category.CATEGORY_SNOWBOARD
                }, new RentItem
                {
                    Id = 4,
                    Name = "kesztyű",
                    Description = "szép kesztyű",
                    Price = 220,
                    Available = true,
                    Category = Category.CATEGORY_PROTECTIVEEQUIPMENTS
                }, new RentItem
                {
                    Id = 5,
                    Name = "sí bot",
                    Description = "hegyes",
                    Price = 200,
                    Available = true,
                    Category = Category.CATEGORY_SKI
                }, new RentItem
                {
                    Id = 6,
                    Name = "snowboard nadrág",
                    Description = "piros, nem engedi át a vizet",
                    Price = 1400,
                    Available = true,
                    Category = Category.CATEGORY_CLOTHING
                }, new RentItem
                {
                    Id = 7,
                    Name = "térdvédő",
                    Description = "védi a térded, fekete",
                    Price = 1050,
                    Available = true,
                    Category = Category.CATEGORY_PROTECTIVEEQUIPMENTS
                },
                new RentItem
                {
                    Id = 8,
                    Name = "kabát",
                    Description = "síkabát",
                    Price = 2500,
                    Available = true,
                    Category = Category.CATEGORY_CLOTHING
                }
            );

            modelBuilder.Entity<RentedItem>().HasData(
                new RentedItem { Id = 1, UserId = 1, RentItemId = 2, StartOfRenting = DateTime.Today, EndOfRenting = DateTime.Today.AddDays(100)   },
                new RentedItem { Id = 2, UserId = 1, RentItemId = 4, StartOfRenting = DateTime.Today, EndOfRenting = DateTime.Today.AddDays(100)   },
                new RentedItem { Id = 3, UserId = 2, RentItemId = 3, StartOfRenting = DateTime.Today, EndOfRenting = DateTime.Today.AddDays(100)   },
                new RentedItem { Id = 4, UserId = 3, RentItemId = 6, StartOfRenting = DateTime.Today, EndOfRenting = DateTime.Today.AddDays(100)   }

            );
        }

    }
}
