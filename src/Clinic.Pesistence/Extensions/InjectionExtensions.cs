using Clinic.Application.Interface.Interfaces;
using Clinic.Pesistence.Context;
using Clinic.Pesistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Clinic.Pesistence.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionPersistence(this IServiceCollection services) 
        {
            services.AddSingleton<ApplicationDBContext>();
            //services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IAnalysisRepository, AnalysisRepository>();

            return services;
        }
    }
}
