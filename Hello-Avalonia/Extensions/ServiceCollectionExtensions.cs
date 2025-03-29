using HelloAvalonia.ViewModel;
using Microsoft.Extensions.DependencyInjection;

namespace HelloAvalonia.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHelloAvaloniaDependencies(this IServiceCollection services)
        {
            return services
                .AddTransient<MainWindow>()
                .AddTransient<MainViewModel>()
                .AddTransient<CustomersViewModel>()
                .AddTransient<ProductsViewModel>();
        }
    }
}