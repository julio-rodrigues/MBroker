using Microsoft.Extensions.DependencyInjection;

namespace MBroker.DataProcessor.Ioc {
    public static class RepositoryServiceExtension {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services) {
            //services.AddTransient<IProductRepository, ProductRepository>();
            //services.AddTransient<IDataContext, DataContext>();

            return services;
        }
    }
}
