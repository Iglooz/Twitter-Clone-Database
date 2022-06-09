﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Clone_ASP.NET.Models;
namespace Twitter_Clone_ASP.NET.Data
{
    public class TwitterDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TwitterDb");
        }
        public static void SeedDatabase()
        {
            using (var db = new TwitterDbContext())
            {
                db.Database.EnsureCreated();
                // Seeds users
                var user1 = db.Users.FirstOrDefault(u => u.Id == 1);
                if(user1 == null)
                {
                    User u1 = new User() { UserName = "Bob3939", TwitterHandle = "Bob Abbot", ImageUrl = "avatar1.jpg", Posts = new List<Post>() };
                    db.Add(u1);
                    db.SaveChanges();
                };
                var user2 = db.Users.FirstOrDefault(u => u.Id == 2);
                if (user2 == null)
                {
                    User u2 = new User() { UserName = "katiejones75", TwitterHandle = "Kate Jones", ImageUrl = "avatar2.jpg", Posts = new List<Post>() };
                    db.Add(u2);
                    db.SaveChanges();
                }
                var user3 = db.Users.FirstOrDefault(u => u.Id == 3);
                if (user3 == null)
                {
                    User u3 = new User() { UserName = "blueskies12", TwitterHandle = "David Chen", ImageUrl = "avatar3.jpg", Posts = new List<Post>() };
                    db.Add(u3);
                    db.SaveChanges();
                }
                var user4 = db.Users.FirstOrDefault(u => u.Id == 4);
                if (user4 == null)
                {
                    User u4 = new User() { UserName = "defaultusername", TwitterHandle = "DefaultUser", ImageUrl = "avatar4.jpg", Posts = new List<Post>() };
                    db.Add(u4);
                    db.SaveChanges();
                }

                // Seeds posts
                var post1 = db.Posts.FirstOrDefault(p => p.Id == 1);
                if(post1 == null)
                {
                    Post p1 = new Post() { Message = "Looking forward to learning more about SQL databases!", Likes = 26, Shares = 5, UserId = 1, User = db.Users.FirstOrDefault(x => x.Id == 1), Edit = false };
                    db.Add(p1);
                    db.SaveChanges();
                }
                var post2 = db.Posts.FirstOrDefault(p => p.Id == 2);
                if (post2 == null)
                {
                    Post p2 = new Post() { Message = "Can you believe all the profile pictures on this website were generated by an AI?", Likes = 301, Shares = 37, UserId = 2, User = db.Users.FirstOrDefault(x => x.Id == 2), Edit = false };
                    db.Add(p2);
                    db.SaveChanges();
                }
                var post3 = db.Posts.FirstOrDefault(p => p.Id == 3);
                if (post3 == null)
                {
                    Post p3 = new Post() { Message = "Beautiful blue skies and golden sunshine, all along the way! Everyone, have a great day :)", Likes = 5196, Shares = 305, UserId = 3, User = db.Users.FirstOrDefault(x => x.Id == 3), Edit = false};
                    db.Add(p3);
                    db.SaveChanges();
                }



                db.SaveChanges();
            }

                
            }
        }
    }

