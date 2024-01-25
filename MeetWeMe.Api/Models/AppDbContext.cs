using MeetWeMe.Model;
using Microsoft.EntityFrameworkCore;

namespace MeetWeMe.Api.Models
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //Seed Departments Table
            modelBuilder.Entity<Categories>().HasData(
           new Categories
           {
               CategoriesId = 1,
               CategoriesName = "Select"

           });
            modelBuilder.Entity<Categories>().HasData(
           new Categories
           {
               CategoriesId = 2,
               CategoriesName = "Glasses"

           });

            modelBuilder.Entity<Categories>().HasData(
           new Categories
           {
               CategoriesId = 3,
               CategoriesName = "Disable"

           });
            modelBuilder.Entity<Categories>().HasData(
          new Categories
          {
              CategoriesId = 4,
              CategoriesName = "Shy"

          });



            //// Seed Employee Table
            //modelBuilder.Entity<Users>().HasData(new Users
            //{
            //    UserId = 1,
            //    Gender = Gender.Male,
            //    PhotoPath = "Images/maxresdefaul.jpg"
            //}) ;
            //modelBuilder.Entity<Users>().HasData(new Users
            //{
            //    UserId = 2,

            //    Gender = Gender.Female,
            //    PhotoPath = "Images/maxresdefaul.jpg"
            //});
            //modelBuilder.Entity<Users>().HasData(new Users
            //{
            //    UserId = 3,

            //    Gender = Gender.Others,
            //    PhotoPath = "Images/maxresdefaul.jpg"
            //});







        }

    }
}
