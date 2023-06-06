using BugTracker.BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL.Data
{
   public class AppDbContext:DbContext
   {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=BugTracker;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
        }

        //Db Set
        public DbSet<Organizations> Organizations { get; set; }
        public DbSet<OrganizationRoles> OrganizationRoles { get; set; }
        public DbSet<OrganizationUsers> OrganizationUsers { get; set; }
        public DbSet<Projects> Projects{ get; set; }
        public DbSet<ProjectRoles> ProjectRoles { get; set; }
        public DbSet<ProjectUser> ProjectUser { get; set; }

        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskDetail> TaskDetail { get; set; }

    }

}
