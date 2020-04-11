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

            modelBuilder.Entity<Travel>()
                        .Property(c => c.AddressOfThePlace)
                        .HasMaxLength(150);

            modelBuilder.Entity<Travel>()
                        .Property(c => c.AddressOfThePlace)
                        .IsRequired();

            modelBuilder.Entity<Travel>()
                        .Property(c => c.Header)
                        .IsRequired();

            modelBuilder.Entity<Travel>()
                        .Property(c => c.Header)
                        .HasMaxLength(100);

            modelBuilder.Entity<Travel>()
                        .Property(c => c.Text)
                        .IsRequired();


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