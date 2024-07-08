using AppsettingsWpf.DAL.Entityes;

using Microsoft.Extensions.DependencyInjection;

namespace AppsettingsWpf.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
           .AddTransient<IRepository<Deal>, DealsRepository>()           
            .AddTransient<IRepository<Picture>, PicturesRepository>()



        ;
    }
}
