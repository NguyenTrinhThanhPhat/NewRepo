using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Identity;

namespace BigSchool.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public ICollection<Following> Followers { get; set; }
        public ICollection<Following> Followees { get; set; }

        public ApplicationUser()
        {
            Followers = new Collection<Following>();
            Followees = new Collection<Following>();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private DbSet<Attendance> attendances;

        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<FollowingNotification> FollowingNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>().HasRequired(a => a.Course)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithRequired(f => f.Followees)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);
        }
    }

    public class IdentityDbContext<T>
    {
        public IdentityDbContext(string v)
        {
            V = v;
        }

        public DbSet<Attendance> Attendances { get => attendances; set => attendances = value; }
        public string V { get; }

        internal void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new NotImplementedException();
        }
    }
    public class DbModelBuilder
    {
        internal object Entity<T>()
        {
            throw new NotImplementedException();
        }
    }

    internal class Attendance
    {
    }
}
