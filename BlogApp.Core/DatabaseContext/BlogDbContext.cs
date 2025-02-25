using BlogApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Core.DatabaseContext
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasOne(e => e.AppUser)
                .WithMany(u => u.BlogPosts)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.AppUser)
                .WithMany(u => u.Comments)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(e => e.BlogPost)
                .WithMany(p => p.Comments)
                .HasForeignKey(e => e.BlogPostId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for AppUser
            modelBuilder.Entity<AppUser>().HasData(
                new AppUser
                {
                    Id = 1,
                    Username = "john_doe",
                    Email = "john.doe@example.com",
                    Password = "pwd1231"
                },
                new AppUser
                {
                    Id = 2,
                    Username = "jane_doe",
                    Email = "jane.doe@example.com",
                    Password = "pwd1231"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
