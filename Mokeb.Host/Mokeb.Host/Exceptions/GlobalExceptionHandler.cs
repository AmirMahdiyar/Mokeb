using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Mokeb.Common.Base.ApplicationExceptions;
using Mokeb.Common.Base.DomainExceptions;
using Mokeb.Common.Base.PresentationExceptions;

namespace Mokeb.Host.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly IHostEnvironment _env;

        public GlobalExceptionHandler(IHostEnvironment env)
        {
            _env = env;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {

            var (statusCode, message) = exception switch
            {
                // BadRequest exceptions
                InputIsWrongApplicationException => (StatusCodes.Status400BadRequest, exception.Message),
                InputValidationFailedApplicationException => (StatusCodes.Status400BadRequest, exception.Message),
                NoChangesApplicationException => (StatusCodes.Status400BadRequest, exception.Message),
                ValidationFailedDomainException => (StatusCodes.Status400BadRequest, exception.Message),
                NoChangesDomainException => (StatusCodes.Status400BadRequest, exception.Message),

                // Unauthorized exceptions
                AuthorizationWithTokenFailedApplicationException => (StatusCodes.Status401Unauthorized, exception.Message),
                AuthorizationFailedPresentationException => (StatusCodes.Status401Unauthorized, exception.Message),

                // Forbidden exceptions
                NotAllowedApplicationException => (StatusCodes.Status403Forbidden, exception.Message),
                NotAllowedDomainException => (StatusCodes.Status403Forbidden, exception.Message),

                // NotFound exceptions
                ObjectNotFoundApplicationException => (StatusCodes.Status404NotFound, exception.Message),
                ObjectNotFoundDomainException => (StatusCodes.Status404NotFound, exception.Message),

                // Conflict exceptions
                ObjectFoundApplicationException => (StatusCodes.Status409Conflict, exception.Message),
                ObjectAlreadyExistDomainException => (StatusCodes.Status409Conflict, exception.Message),

                // Generic exceptions
                _ => (StatusCodes.Status500InternalServerError, _env.IsDevelopment() ? exception.Message : "خطایی در سرور رخ داده است.")
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            var response = new
            {
                success = false,
                message = message
            };

            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
