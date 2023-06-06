using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL
{
   public class BaseEntity
   {
        [Key]
        public Guid Id { get; set; }
        public BaseEntity()
        {

        }

        public BaseEntity(Guid id)
        {
            Id = id;
        }
    }
}
