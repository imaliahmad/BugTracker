using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.BOL.DataTypes
{
    /// <summary>
    /// Represents the status types for tasks in BugTracker.
    /// </summary>
    public enum StatusTypes
    {
        /// <summary>
        /// Task is assigned.
        /// </summary>
        Assigned,

        /// <summary>
        /// Task is not assigned.
        /// </summary>
        NotAssigned,

        /// <summary>
        /// Task is in progress.
        /// </summary>
        Progress,

        /// <summary>
        /// Task is completed.
        /// </summary>
        Completed,

        /// <summary>
        /// Task is cancelled.
        /// </summary>
        Cancelled
    }
}
