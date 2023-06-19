namespace BugTracker.Web.Models
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Gets or sets the message associated with the response.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the data associated with the response.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the list of errors associated with the response.
        /// </summary>
        public List<string> Errors { get; set; }
    }
}
