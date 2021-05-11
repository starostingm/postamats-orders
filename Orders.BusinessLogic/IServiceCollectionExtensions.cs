using Microsoft.Extensions.DependencyInjection;
using Orders.BusinessLogic.Services.Orders;
using Orders.BusinessLogic.Services.Orders.Interfaces;
using Orders.BusinessLogic.Services.Postamats;
using Orders.BusinessLogic.Services.Postamats.Interfaces;
using Orders.BusinessLogic.Validators.PhoneNumberValidator;
using Orders.BusinessLogic.Validators.PhoneNumberValidator.Interfaces;
using Orders.BusinessLogic.Validators.PostamatNumberValidator;
using Orders.BusinessLogic.Validators.PostamatNumberValidator.Interfaces;

namespace Orders.BusinessLogic
{
    public static class IServiceCollectionExtensions
    {
        public static void RegisterOrdersBuisnessLogic(this IServiceCollection services)
        {
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IPostamatsService, PostamatsService>();

            services.AddTransient<IPhoneNumberValidator, PhoneNumberValidator>();
            services.AddTransient<IPostamatNumberValidator, PostamatNumberValidator>();
        }
    }
}
