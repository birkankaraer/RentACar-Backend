using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json"; //tarayıcımıza ben sana bir tane json yolladım. Haberin olsun.
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //burada ise bizim doğrulama hatalarını yönettiğimiz yer, kendi hata yönetimimiz
            string message = "Internal Server Error";
            IEnumerable<ValidationFailure> validationErrors = ((ValidationException)e).Errors;
            if (e.GetType() == typeof(ValidationException))//hatanın türünü kontrol ettim, eğer doğrulama hatası ise ona göre bir dönüş gerçekleştirdim
            {
                message = "Bad Request";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                

                return httpContext.Response.WriteAsync(new ValidationErrorDetails()
                {
                    StatusCode = 400,
                    Message = message,
                    ValidationErrors = validationErrors
                }.ToString());
            }
            //burası sistemsel gelen hata için 
            return httpContext.Response.WriteAsync(new ErrorDetails
            {
                StatusCode = httpContext.Response.StatusCode,
                Message = message
            }.ToString());
        }
    }
}
