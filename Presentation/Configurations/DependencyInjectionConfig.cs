using api_csharp.Application.UseCases.Users;
using api_csharp.Application.UseCases.TodoTasks;
using api_csharp.Application.Services;

namespace api_csharp.Presentation.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection services)
        {
            // Injeção dos Serviços de Usuario
            services.AddScoped<UserService>();
            services.AddScoped<TodoTaskService>();
            //services.AddScoped<TokenService>();

            // Injeção dos Use Cases de Usuário
            services.AddScoped<CreateUserUseCase>();
            services.AddScoped<LoginUserUseCase>();
            services.AddScoped<GetUserUseCase>();
            services.AddScoped<UpdateUserUseCase>();
            services.AddScoped<UpdateStatusTodoTaskUseCase>();
            services.AddScoped<RemoveTodoTaskUseCase>();

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