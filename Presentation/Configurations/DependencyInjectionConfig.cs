using api_csharp.Application.UseCases.Users;
using api_csharp.Application.UseCases.TodoTasks;

namespace api_csharp.Presentation.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services)
        {
            // Injeção dos Use Cases de Usuário
            services.AddScoped<CreateUserUseCase>();
            services.AddScoped<LoginUserUseCase>();

            // Injeção dos Use Cases de Tarefas
            services.AddScoped<CreateTodoTaskUseCase>();
            services.AddScoped<UpdateTodoTaskUseCase>();
            services.AddScoped<GetAllTodoTaskUseCase>();
            services.AddScoped<GetTodoTaskUseCase>();
            services.AddScoped<RemoveTodoTaskUseCase>();

            return services;
        }
    }
}