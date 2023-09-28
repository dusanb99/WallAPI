using Microsoft.EntityFrameworkCore;
using WallAPI.Models;

namespace WallAPI
{
    public class WallDbContext : DbContext
    {


        public WallDbContext(DbContextOptions options) : base(options)
        {
             
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(u =>
            {
                u.HasKey(x => x.Id);
                u.HasMany(x => x.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Post>(p =>
            {
                p.HasKey(x => x.Id);
                p.HasOne(x => x.User)
                .WithMany(p => p.Posts)
                .OnDelete(DeleteBehavior.Restrict);
                p.HasMany(x => x.Comments)
                .WithOne(c => c.OriginPost);
            });

            modelBuilder.Entity<Comment>(c =>
            {
                c.HasKey(x => x.Id);
                c.HasOne(x => x.OriginPost)
                .WithMany(p => p.Comments)
                .HasForeignKey(x => x.OriginPostId)
                .OnDelete(DeleteBehavior.Restrict);
            });



        }
    }


    }

