using Checkout.Common.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace Checkout.Common.Infrastructure.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }

    }
}
