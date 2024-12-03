using DsInsurance.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace DsInsurance.Exceptions
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext,
                                              Exception exception,
                                              CancellationToken cancellationToken)
        {
            var response = new ErrorResponse();
            if (exception is AlreadyExistsException)
            {
                response.StatusCode = StatusCodes.Status409Conflict;
                response.ExceptionMessage = exception.Message;
                response.Title = "Conflict Detected";
            }
            else if(exception is NotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                response.ExceptionMessage = exception.Message;
                response.Title = "Resource Not Found";
            }
            else
            {
                response.StatusCode = StatusCodes.Status500InternalServerError;
                response.ExceptionMessage = "An unexpected error occurred.";
                response.Title = "Internal Server Error";
            }
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);
            return true;
        }
    }
}

