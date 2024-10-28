using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Infrastructure.Repositories;
using ApplicationForTrainingWEB.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IStandardMealRepository, StandardMealRepository>();
            services.AddTransient<IUserMealRepository, UserMealRepository>();
            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IWorkoutRepository, WorkoutRepository>();
            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IReadyRecipesRepository, ReadyRecipesRepository>();
            services.AddTransient<IReadyPlanWorkoutRepository, ReadyPlanWorkoutRepository>();
            return services;
        }
    }
}
