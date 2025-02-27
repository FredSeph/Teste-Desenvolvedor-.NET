using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Vestibular.Repository.Interfaces;
using Vestibular.Repository.Repositories;

namespace Vestibular.DependencyInjection
{
    public static class Register
    {
        public static void RegisterRepositories(IServiceCollection services)
        {
            AddRepositories(services);
            AddBusiness(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            var assemblyRepository = Assembly.Load("Vestibular.Repository");

            // Registra o repositório genérico.
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            // Obtém todos os tipos que são classes e implementam interface IBaseRepository.
            var types = assemblyRepository.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))).ToList();

            foreach (var type in types)
            {
                // Obtém a interface correspondente ao repositório.
                var @interface = type.GetInterfaces().FirstOrDefault(i => !i.IsGenericType && i.GetInterfaces().Any(ii => ii.IsGenericType && ii.GetGenericTypeDefinition() == typeof(IBaseRepository<>)));

                if (@interface != null)
                {
                    // Registra o repositório no container.
                    services.AddScoped(@interface, type);
                }
            }
        }

        private static void AddBusiness(IServiceCollection services)
        {
            var assemblyBusiness = Assembly.Load("Vestibular.Business");

            // Obtém todos os tipos que são classes.
            var types = assemblyBusiness.GetTypes().Where(t => t.IsClass && !t.IsAbstract).ToList();

            foreach (var type in types)
            {
                // Obtém a interface correspondente ao business.
                var @interface = type.GetInterfaces().FirstOrDefault(i => !i.IsGenericType);

                if (@interface != null)
                {
                    // Registra o business no container.
                    services.AddScoped(@interface, type);
                }
            }
        }
    }
}
