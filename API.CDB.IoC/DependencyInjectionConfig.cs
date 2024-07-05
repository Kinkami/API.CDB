using API.Cdb.Domain.Interfaces.Business;
using API.CDB.Business.Business;
using Microsoft.Extensions.DependencyInjection;

namespace API.Cdb.IoC
{
    public class DependencyInjectionConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICdbBusiness, CdbBusiness>();
        }
    }
}
