using Microsoft.Extensions.DependencyInjection;
using Orders.Data.Orders;
using Orders.Data.Orders.Interfaces;
using Orders.Data.Postamats;
using Orders.Data.Postamats.Interfaces;

namespace Orders.Data
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterOrdersData(this IServiceCollection services)
        {
            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IPostamatsRepository, PostamatsRepository>();
        }
    }
}
