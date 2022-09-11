using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MBroker.DataProcessor.Ioc {
    public static class BusinessServiceExtension {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services) {
            //services.AddTransient<IProductService, ProductService>();

            return services;
        }
    }
}
