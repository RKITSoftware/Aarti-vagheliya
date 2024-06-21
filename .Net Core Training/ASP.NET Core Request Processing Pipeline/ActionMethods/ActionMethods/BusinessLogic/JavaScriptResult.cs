using Microsoft.AspNetCore.Mvc;

namespace ActionMethods.BusinessLogic
{
    /// <summary>
    /// Represents an action result that returns JavaScript content.
    /// </summary>
    public class JavaScriptResult : ActionResult
    {
        /// <summary>
        /// Gets the JavaScript content to be returned.
        /// </summary>
        public string Script { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaScriptResult"/> class with the specified script content.
        /// </summary>
        /// <param name="script">The JavaScript content to be returned.</param>
        public JavaScriptResult(string script)
        {
            Script = script;
        }

        /// <summary>
        /// Executes the result operation asynchronously. Writes the JavaScript content to the response.
        /// </summary>
        /// <param name="context">The context in which the result is executed.</param>
        /// <returns>A task that represents the asynchronous execute operation.</returns>
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "application/javascript";
            await response.WriteAsync(Script);
        }
    }
}
