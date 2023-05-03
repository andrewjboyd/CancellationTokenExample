namespace WebApiPlayAround
{
    public class TaskCanceledExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TaskCanceledExceptionMiddleware> _logger;

        public TaskCanceledExceptionMiddleware(RequestDelegate next, ILogger<TaskCanceledExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (TaskCanceledException)
            {
                //_logger.LogError(ex, "A task was canceled");
                //// re-throw the exception so that the middleware pipeline can handle it
                //throw;
            }
        }
    }

}
