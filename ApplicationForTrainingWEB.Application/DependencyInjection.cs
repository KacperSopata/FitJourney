using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.Services;
using ApplicationForTrainingWEB.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IStandardMealService, StandardMealService>();
            services.AddTransient<IUserMealService, UserMealService>();
            services.AddTransient<IExerciseService, ExerciseService>();
            services.AddTransient<IWorkoutService, WorkoutService>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IReadyRecipesService, ReadyRecipesService>();
            services.AddTransient<IReadyPlanWorkoutService, ReadyPlanWorkoutService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
