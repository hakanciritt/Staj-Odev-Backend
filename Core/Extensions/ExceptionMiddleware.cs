using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public class ExceptionMiddleware
    {
        private RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HanldeExceptionAsync(context, exception);
            }

        }
        private Task HanldeExceptionAsync(HttpContext context,Exception exception)
        {
            IEnumerable<ValidationFailure> errors;

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = "Internal server error";

            if (exception.GetType() == typeof(ValidationException))
            {
                message = exception.Message;
                errors = ((ValidationException)exception).Errors;
                context.Response.StatusCode = 400;

                return context.Response.WriteAsync(new ValidationErrorDetails
                {
                    Errors = errors,
                    Message = message,
                    StatusCode = 400
                }.ToString());
            }
            return context.Response.WriteAsync(new ErrorDetails
            {
                Message=message,
                StatusCode=context.Response.StatusCode
            }.ToString());
        }
    }
}
