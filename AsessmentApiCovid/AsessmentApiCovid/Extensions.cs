using AsessmentApiCovid.Data;
using AsessmentApiCovid.Wrapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsessmentApiCovid
{
    public static class Extensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            

            services.AddSingleton<ApplicationDbContext>();

        }

        public static void RegisterService(this IServiceCollection services)
        {
            
            services.AddScoped<IWrappers, Wrappers>();
        }
    }
}
