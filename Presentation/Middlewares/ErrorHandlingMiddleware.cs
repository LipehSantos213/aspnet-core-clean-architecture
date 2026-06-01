using System.Net;
using System.Text.Json;
using api_csharp.Domain.Exception; // Suas exceções de domínio

namespace api_csharp.Presentation.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Segue o fluxo normal da requisição
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 por padrão

            // Se o erro veio do seu domínio (regrade negócio violada), mandamos 400
            if (exception is DomainException) code = HttpStatusCode.BadRequest;

            var result = JsonSerializer.Serialize(new { message = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }
}