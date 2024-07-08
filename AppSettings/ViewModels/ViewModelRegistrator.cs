using Microsoft.Extensions.DependencyInjection;

namespace AppsettingsWpf.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
           .AddScoped<MainWindowViewModel>()
        ;
    }
}
