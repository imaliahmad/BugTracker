﻿using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    /// <summary>
    /// Represents the database operations for organization users.
    /// </summary>
    public interface IOrganizationUsersDb
    {
        /// <summary>
        /// Gets all the organization users.
        /// </summary>
        /// <returns>The collection of organization users.</returns>
        IEnumerable<AppUsers> GetAll();

        /// <summary>
        /// Gets an organization user by ID.
        /// </summary>
        /// <param name="id">The ID of the organization user.</param>
        /// <returns>The organization user.</returns>
        AppUsers GetById(int id);

        /// <summary>
        /// Inserts a new organization user.
        /// </summary>
        /// <param name="obj">The organization user object to insert.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Insert(AppUsers obj);

        /// <summary>
        /// Updates an existing organization user.
        /// </summary>
        /// <param name="obj">The organization user object to update.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Update(AppUsers obj);

        /// <summary>
        /// Deletes an organization user by ID.
        /// </summary>
        /// <param name="id">The ID of the organization user to delete.</param>
        /// <returns>True if the operation was successful, otherwise false.</returns>
        bool Delete(int id);
    }

    /// <summary>
    /// Represents the implementation of the organization users database operations.
    /// </summary>
    public class AppUsersDb : IOrganizationUsersDb
    {
        private AppDbContext context;

        /// <summary>
        /// Initializes a new instance of the AppUsersDb class with the specified database context.
        /// </summary>
        /// <param name="_context">The application database context.</param>
        public AppUsersDb(AppDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<AppUsers> GetAll()
        {
            return context.AppUsers.ToList();
        }

        public AppUsers GetById(int id)
        {
            var obj = context.AppUsers.Find(id);
            return obj;
        }

        
        public bool Insert(AppUsers obj)
        {
            context.AppUsers.Add(obj);
            context.SaveChanges();
            return true;
        }

       
        public bool Update(AppUsers obj)
        {
            context.AppUsers.Update(obj);
            context.SaveChanges();
            return true;
        }

        
        public bool Delete(int id)
        {
            var obj = context.AppUsers.Find(id);
            context.AppUsers.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
