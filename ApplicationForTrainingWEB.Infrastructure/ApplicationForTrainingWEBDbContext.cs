using ApplicationForTrainingWEB.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Infrastructure
{
    public class ApplicationForTrainingWEBDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealProduct> MealProducts { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ReadyRecipes> ReadyRecipes { get; set; }
        public DbSet<ReadyPlanWorkout> ReadyPlanWorkouts { get; set; }
        public ApplicationForTrainingWEBDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}