using ApplicationForTrainingWEB.Application.ViewModels.WorkoutVm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Interfaces
{
    public interface IWorkoutService
    {
        WorkoutDetailVm GetWorkout(string userId, DateTime selectedDate);
        void DeleteProduct(int id);
        int AddExerciseToWorkout(NewWorkoutExerciseVm exercise);
        Task<int> AddWorkout(NewWorkoutVm product);
        void DeleteWorkout(int workoutid);
        NewWorkoutExerciseVm GetWorkoutExerciseById(int id);
        void UpdateExercise(NewWorkoutExerciseVm model);

    }
}