using AgendaMedica.Application.QueryRepositories;
using AgendaMedica.Domain.CommandRepositories;
using AgendaMedica.Infrastructure.Persistence;
using AgendaMedica.Infrastructure.Repositories.Command;
using AgendaMedica.Infrastructure.Repositories.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaMedica.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // DbContext
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Patron Mediator para CQRS
            services.AddTransient<IMediator, Mediator>();
            services.Scan(scan => scan
                .FromAssembliesOf(typeof(IMediator))
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());


            // Repositorios
            services.AddScoped<IMedicoQueryRepository, MedicoQueryRepository>();
            services.AddScoped<IPacienteQueryRepository, PacienteQueryRepository>(); 
            services.AddScoped<IMedicoCommandRepository, MedicoCommandRepository>();
            services.AddScoped<IPacienteCommandRepository, PacienteCommandRepository>();

            return services;
        }
    }
}
