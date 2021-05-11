using Microsoft.AspNetCore.Builder;

namespace Orders.Api.Middlewares.ExceptionsMiddleware
{
    public static class IApplicationBuilderExtensions
    {
        public static void UseExceptionsMiddleware(this IApplicationBuilder appBuilder)
        {
            appBuilder.UseMiddleware<ExceptionsMiddleware>();
        }
    }
}
