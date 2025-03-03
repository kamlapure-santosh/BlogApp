﻿using BlogApp.Core.Entities;
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
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogCategory>();

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
            // Seed data for BlogCategory
            modelBuilder.Entity<BlogCategory>().HasData(
                new BlogCategory
                {
                    Id = 1,
                    CategoryName = "Pets",
                },
                new BlogCategory
                {
                    Id = 2,
                    CategoryName = "Travel",
                },
                new BlogCategory
                {
                    Id = 3,
                    CategoryName = "Intertainment",
                },
                new BlogCategory
                {
                    Id = 4,
                    CategoryName = "Social Media",
                },
                new BlogCategory
                {
                    Id = 5,
                    CategoryName = "Marketing",
                },
                new BlogCategory
                {
                    Id = 6,
                    CategoryName = "Shopping",
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
