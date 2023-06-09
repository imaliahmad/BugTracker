using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL.DataTypes
{
    /// <summary>
    /// Represents the priority levels for tasks in BugTracker.
    /// </summary>
    public enum PriorityTypes
    {
        /// <summary>
        /// High priority.
        /// </summary>
        High,

        /// <summary>
        /// Medium priority.
        /// </summary>
        Medium,

        /// <summary>
        /// Low priority.
        /// </summary>
        Low,

        /// <summary>
        /// Urgent priority.
        /// </summary>
        Urgent
    }
}
