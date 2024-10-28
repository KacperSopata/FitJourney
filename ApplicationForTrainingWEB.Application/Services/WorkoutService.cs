using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.ViewModels.WorkoutVm;
using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Services
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepo;
        private readonly IExerciseRepository _exerciseRepo;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public WorkoutService(IWorkoutRepository workoutRepo, IExerciseRepository exerciseRepo, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _workoutRepo = workoutRepo;
            _exerciseRepo = exerciseRepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public WorkoutDetailVm GetWorkout(string userId, DateTime selectedDate)
        {
            var workout = _workoutRepo.GetWorkout(selectedDate, userId);
            if (workout == null)
            {
                return new WorkoutDetailVm(); // Zwracamy pusty model, jeśli trening nie istnieje
            }

            var exercises = _workoutRepo.GetExercises(workout.Id, userId); // Pobieramy ćwiczenia z bazy danych
            var workoutVm = _mapper.Map<WorkoutDetailVm>(workout);

            if (exercises != null && exercises.Any())
            {
                workoutVm.Exercises = exercises.Select(e => _mapper.Map<ExerciseForListVm>(e)).ToList();

                // Debugowanie: sprawdź, czy nazwy ćwiczeń są poprawnie wypełnione
                foreach (var exercise in workoutVm.Exercises)
                {
                    Console.WriteLine("Ćwiczenie: " + exercise.Name); // Zobacz, co się wyświetla w logach
                }
            }

            return workoutVm;
        }

        public int AddExerciseToWorkout(NewWorkoutExerciseVm exercise)
        {
            var exer = _mapper.Map<WorkoutExercise>(exercise);
            var id = _workoutRepo.AddExercise(exer);
            return id;
        }

        public void DeleteProduct(int id)
        {
            _workoutRepo.DeleteProduct(id);
        }


        public async Task<int> AddWorkout(NewWorkoutVm product)
        {
            var prod = _mapper.Map<Workout>(product);
            var user = await _userManager.FindByIdAsync(product.UserId);
            if (user == null)
            {
                throw new ArgumentException("Invalid user ID.");
            }
            prod.ApplicationUser = user;
            var id = _workoutRepo.AddWorkout(prod);
            return id;

        }

        public void DeleteWorkout(int workoutid)
        {
            _workoutRepo.DeleteWorkout(workoutid);
        }

        public NewWorkoutExerciseVm GetWorkoutExerciseById(int id)
        {
            var exercise = _workoutRepo.GetWorkoutExerciseById(id);
            var exerciseVm = _mapper.Map<NewWorkoutExerciseVm>(exercise);
            return exerciseVm;
        }

        public void UpdateExercise(NewWorkoutExerciseVm model)
        {
            var workoutexercise = _mapper.Map<WorkoutExercise>(model);
            _workoutRepo.UpdateProduct(workoutexercise);
        }

    }
}