namespace BugTracker.API.DTOs.Response
{
    /// <summary>
    /// Represents the response format for JSON responses.
    /// </summary>
    public class JsonResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the response is successful.
        /// </summary>
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
