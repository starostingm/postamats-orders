using Microsoft.AspNetCore.Http;
using Orders.BusinessLogic.Services.Orders.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orders.Api.Middlewares.ExceptionsMiddleware
{
    public class ExceptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (TooMuchGoodsException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            catch (InvalidPhoneNumberException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            catch (InvalidPostamatNumberException)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
            catch (PostamatNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            catch (InvalidPostamatException)
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
            }
            catch (OrderNotFoundException)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
            }
        }
    }
}
