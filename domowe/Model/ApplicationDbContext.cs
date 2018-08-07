using domowe.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domowe.Model
{
    class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=AppDbConnectionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            modelBuilder.Entity<Teacher>().HasOptional(t => t.Subject).WithRequired().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);

        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

    }
}
