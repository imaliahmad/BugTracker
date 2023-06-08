using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IOrganizationUsersDb
    {
        IEnumerable<AppUsers> GetAll();
        AppUsers GetById(int id);
        bool Insert(AppUsers obj);
        bool Update(AppUsers obj);
        bool Delete(int id);
    }
    public class AppUsersDb : IOrganizationUsersDb
    {
        private AppDbContext context;
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
