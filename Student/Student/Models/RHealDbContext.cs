using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Student.Models
{
    public class RHealDbContext : DbContext
    {
        public RHealDbContext() : base("name=RHealDbConnections")
        {
        }

        // define DbSet<T> for Categories and Products
        public DbSet<StudentInfo> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public DbSet<Trainer>Trainers{get; set;}
        public DbSet<Studentcource> Studentcources { get; set; }

        /// <summary>
        /// Create Tables mapped with Model classes or entity classes 
        /// used through the DbSet<T> poroperties e.g. Categories and Products
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}