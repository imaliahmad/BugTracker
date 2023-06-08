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
            optionsBuilder.UseSqlServer(@"Server=MEHROZQAZI-PC\SQLEXPRESS;Database=BugTrackerA;Trusted_Connection=True");
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
        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<Projects> Projects{ get; set; }
        public DbSet<ProjectUser> ProjectUser { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TaskHistory> TaskHistory { get; set; }
        public DbSet<AttachmentMaster> AttachmentMaster { get; set; }
        public DbSet<TaskAttachments> TaskAttachments { get; set; }
        public DbSet<TaskComments> TaskComments{ get; set; }



    }

}
