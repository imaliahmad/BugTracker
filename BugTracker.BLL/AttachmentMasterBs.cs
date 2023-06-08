using BugTracker.BOL;
using BugTracker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BLL
{
    public interface IAttachmentMasterBs
    {
        IEnumerable<AttachmentMaster> GetAll();
        AttachmentMaster GetById(int id);
        bool Insert(AttachmentMaster obj);
        bool Update(AttachmentMaster obj);
        bool Delete(int id);
    }
    public class AttachmentMasterBs : IAttachmentMasterBs
    {
        private readonly IAttachmentMasterDb objDb;

        public AttachmentMasterBs(IAttachmentMasterDb _objDb)
        {
            objDb = _objDb;
        }
        public IEnumerable<AttachmentMaster> GetAll()
        {
            return objDb.GetAll();
        }
        public AttachmentMaster GetById(int id)
        {
            return objDb.GetById(id);
        }
        public bool Insert(AttachmentMaster obj)
        {
            return objDb.Insert(obj);
        }
        public bool Update(AttachmentMaster obj)
        {
            return objDb.Update(obj);
        }
        public bool Delete(int id)
        {
            return objDb.Delete(id);
        }
    }
}
