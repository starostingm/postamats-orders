using Microsoft.Extensions.DependencyInjection;
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
            services.AddTransient<IPhoneNumberValidator, PhoneNumberValidator>();
            services.AddTransient<IPostamatNumberValidator, PostamatNumberValidator>();
        }
    }
}
