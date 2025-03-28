using Microsoft.Extensions.DependencyInjection;

namespace Hello_Avalonia.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddHelloAvaloniaDependencies(this IServiceCollection services)
        {
            return services
                .AddTransient<MainWindow>()
                .AddTransient<MainViewModel>();
        }
    }
}