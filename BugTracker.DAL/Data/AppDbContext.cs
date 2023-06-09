using BugTracker.BOL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL.Data
{
    /// <summary>
    /// Represents the application's database context.
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the AppDbContext class with the specified options.
        /// </summary>
        /// <param name="options">The options for configuring the database context.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Configures the model for the database context.
        /// </summary>
        /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            // Configure table names and delete behavior for relationships
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetTableName(entityType.DisplayName());

                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }

            base.OnModelCreating(modelBuilder);
        }

        // Db Sets for entity types


        /// <summary>
        /// Gets or sets the collection of organizations.
        /// </summary>
        public DbSet<Organizations> Organizations { get; set; }

        /// <summary>
        /// Gets or sets the collection of application users.
        /// </summary>
        public DbSet<AppUsers> AppUsers { get; set; }

        /// <summary>
        /// Gets or sets the collection of projects.
        /// </summary>
        public DbSet<Projects> Projects { get; set; }

        /// <summary>
        /// Gets or sets the collection of project users.
        /// </summary>
        public DbSet<ProjectUser> ProjectUser { get; set; }

        /// <summary>
        /// Gets or sets the collection of tasks.
        /// </summary>
        public DbSet<Tasks> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the collection of task histories.
        /// </summary>
        public DbSet<TaskHistory> TaskHistory { get; set; }

        /// <summary>
        /// Gets or sets the collection of attachment masters.
        /// </summary>
        public DbSet<AttachmentMaster> AttachmentMaster { get; set; }

        /// <summary>
        /// Gets or sets the collection of task attachments.
        /// </summary>
        public DbSet<TaskAttachments> TaskAttachments { get; set; }

        /// <summary>
        /// Gets or sets the collection of task comments.
        /// </summary>
        public DbSet<TaskComments> TaskComments { get; set; }
    }
}








