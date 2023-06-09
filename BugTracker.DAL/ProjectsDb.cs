﻿using BugTracker.BOL;
using BugTracker.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    /// <summary>
    /// Represents the database operations for projects.
    /// </summary>
    public interface IProjectsDb
    {
        /// <summary>
        /// Gets all the projects.
        /// </summary>
        /// <returns>The collection of projects.</returns>
        IEnumerable<Projects> GetAll();

        /// <summary>
        /// Gets a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns>The project.</returns>
        Projects GetById(Guid id);

        /// <summary>
        /// Inserts a new project.
        /// </summary>
        /// <param name="obj">The project object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        Projects Insert(Projects obj);

        /// <summary>
        /// Updates an existing project.
        /// </summary>
        /// <param name="obj">The project object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        Projects Update(Projects obj);

        /// <summary>
        /// Deletes a project by ID.
        /// </summary>
        /// <param name="id">The ID of the project to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(Guid id);
    }

    /// <summary>
    /// Represents the implementation of the projects database operations.
    /// </summary>
    public class ProjectsDb : IProjectsDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the ProjectsDbclass with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public ProjectsDb(AppDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<Projects> GetAll()
        {
            var list = context.Projects
                                        .Include(o => o.Organizations)
                                        .Select(x => new Projects()
                                        {
                                            Id = x.Id,
                                            Name = x.Name,                                          
                                            Organizations = x.Organizations,
                                            OrgId = x.OrgId,
                                            StartDate = x.StartDate,
                                            EndDate = x.EndDate,

                                        }).ToList();
            return list;
        }

        
        public Projects GetById(Guid id)
        {
            var obj = context.Projects.Find(id);
            return obj;
        }

        
        public Projects Insert(Projects obj)
        {
            context.Projects.Add(obj);
            context.SaveChanges();
            return obj;
        }

       
        public Projects Update(Projects obj)
        {
            context.Projects.Update(obj);
            context.SaveChanges();
            return obj;
        }

       
        public bool Delete(Guid id)
        {
            var obj = context.Projects.Find(id);
            context.Projects.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
