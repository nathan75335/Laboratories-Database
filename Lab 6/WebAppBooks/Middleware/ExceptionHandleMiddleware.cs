using BusinessLogic.Exceptions;

namespace WebAppBooks.Middleware
{
    /// <summary>
    /// The class exception handler
    /// </summary>
    public class ExceptionHandleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandleMiddleware> _logger;

        /// <summary>
        /// Initializes a new instance of <see cref="ExceptionHandleMiddleware"/>
        /// </summary>
        /// <param name="next">The request delegate</param>
        /// <param name="logger">The logger</param>
        public ExceptionHandleMiddleware(RequestDelegate next, ILogger<ExceptionHandleMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        /// Function to call that will be run in the middleware
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);

            }catch(Exception ex)
            {
                if(ex.GetType() == typeof(NotFoundException)) 
                {
                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                    await context.Response.WriteAsync(ex.Message);
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(ex.Message);
                }
            }
        }
    }
}
