using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelUp.Model;

namespace TravelUp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Travel> AllTravels { get; set; }
        public DbSet<User> AllUsers { get; set; }
        public DbSet<Rating> AllRatings { get; set; }
        public DbSet<TravelUserFavouriteList> TravelUserFaMTMs { get; set; }
        public DbSet<TravelUserVisitedList> TravelUserVisMTMs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region travel
            modelBuilder.Entity<Travel>()
            .HasKey(c => c.Id);

            modelBuilder.Entity<Travel>()
                        .HasOne(c => c.Rating);
            modelBuilder.Entity<Travel>()
                        .HasOne(c => c.Author);

            modelBuilder.Entity<Travel>()
                        .HasOne(c => c.Rating);

            /*            modelBuilder.Entity<Travel>()
                                    .ToTable("Travels");



            *//*           *//*

                        modelBuilder.Entity<Travel>()
                                    .HasOne(c => c.Rating);

                        modelBuilder.Entity<Travel>()
                                    .Property(c => c.Header)
                                    .HasMaxLength(50);*/

            #endregion

            #region Rating
            modelBuilder.Entity<Rating>()
                        .ToTable("Ratings");

            modelBuilder.Entity<Rating>()
                        .HasKey(c => c.Id);
            #endregion




            #region MTM TravelUserFavouriteList

            modelBuilder.Entity<TravelUserFavouriteList>()
                .HasKey(c => new { c.TravelId, c.UserId });

            modelBuilder.Entity<TravelUserFavouriteList>()
                        .HasOne<User>(c => c.User)
                        .WithMany(c => c.OnFavouriteList)
                        .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<TravelUserFavouriteList>()
                        .HasOne<Travel>(c => c.Travel)
                        .WithMany(c => c.OnFavouriteList)
                        .HasForeignKey(c => c.TravelId);
            #endregion

            #region MTM TravelUserVisitedList
            modelBuilder.Entity<TravelUserVisitedList>()
                         .HasKey(c => new { c.TravelId, c.UserId });

            modelBuilder.Entity<TravelUserVisitedList>()
                        .HasOne<User>(c => c.User)
                        .WithMany(c => c.OnVisitedList)
                        .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<TravelUserVisitedList>()
                        .HasOne<Travel>(c => c.Travel)
                        .WithMany(c => c.OnVisitedList)
                        .HasForeignKey(c => c.TravelId);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

    }
}