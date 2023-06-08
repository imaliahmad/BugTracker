using BugTracker.BOL;
using BugTracker.DAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.DAL
{
    public interface IAttachmentMasterDb
    {
        IEnumerable<AttachmentMaster> GetAll();
        AttachmentMaster GetById(int id);
        bool Insert(AttachmentMaster obj);
        bool Update(AttachmentMaster obj);
        bool Delete(int id);
    }
    public class AttachmentMasterDb : IAttachmentMasterDb
    {
        private AppDbContext context;
        public AttachmentMasterDb(AppDbContext _context)
        {
            context = _context;
        }
        public IEnumerable<AttachmentMaster> GetAll()
        {
            return context.AttachmentMaster.ToList();
        }
        public AttachmentMaster GetById(int id)
        {
            var obj = context.AttachmentMaster.Find(id);
            return obj;
        }
        public bool Insert(AttachmentMaster obj)
        {
            context.AttachmentMaster.Add(obj);
            context.SaveChanges();
            return true;
        }
        public bool Update(AttachmentMaster obj)
        {
            context.AttachmentMaster.Update(obj);
            context.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var obj = context.AttachmentMaster.Find(id);
            context.AttachmentMaster.Remove(obj);
            context.SaveChanges();
            return true;
        }
    }
}
