using Clinic.Application.UseCase.Commons.Bases;
using Clinic.Application.UseCase.Commons.Exceptions;
using Clinic.Utilities.Constants;
using System.Text.Json;

namespace Clinic.API.Extensions.Middleware
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.ContentType = "application/json";
                await JsonSerializer.SerializeAsync(context.Response.Body, new BaseResponse<object>
                {
                    Message = GlobalMessages.MESSAGE_VALIDATE, //"Errores de Validacion",
                    Errors = ex.Errors
                });
            }
        }
    }
}
