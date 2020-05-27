using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WPf_EFCore.Model;
using System.Configuration;

namespace WPf_EFCore.DAL
{
    public class TopicContext : DbContext
    {
        public TopicContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();

        }
        public TopicContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder opt)
        {
            var connectionString = "Server=localhost;Database=TopicDb;Trusted_Connection=True;";
                //"Server=(localdb)\\usersdb;Database=TopicDb;Trusted_Connection=True;";
            //"Server=localhost;Database=TopicDb;Trusted_Connection=True;";
            opt.UseSqlServer(connectionString);
            base.OnConfiguring(opt);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            //var testTopic = new Topic
            //{
            //    Id = 1,
            //    Text = "test"
            //};
            //modelBuilder.Entity<Topic>().HasData(testTopic);
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EliteRestaurantDb;Integrated Security=True;";
        //    optionsBuilder.UseSqlServer(connectionString);
        //    base.OnConfiguring(optionsBuilder);

            //}
        public DbSet<Topic> Topics { get; set; }
    }
}
