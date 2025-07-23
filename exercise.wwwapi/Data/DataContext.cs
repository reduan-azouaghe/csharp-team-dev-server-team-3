using exercise.enums;
using exercise.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Reflection;

namespace exercise.wwwapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
       
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<DeliveryLogLine> DeliveryLogLine { get; set; }
        public DbSet<Cohort> Cohort { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<DeliveryLog> DeliveryLogs { get; set; }
       
    }
}
