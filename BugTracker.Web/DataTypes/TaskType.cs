using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Web.DataTypes
{
    /// <summary>
    /// Represents the types of tasks in BugTracker.
    /// </summary>
    public enum TaskType
    {
        /// <summary>
        /// Represents a bug task.
        /// </summary>
        Bug,

        /// <summary>
        /// Represents a general task.
        /// </summary>
        Task,

        /// <summary>
        /// Represents a research task.
        /// </summary>
        Research
    }
}
