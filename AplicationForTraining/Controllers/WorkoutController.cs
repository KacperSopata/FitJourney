using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.Services;
using ApplicationForTrainingWEB.Application.ViewModels.WorkoutVm;
using ApplicationForTrainingWEB.Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AplicationForTraining.Controllers
{
    namespace AplicationForTraining.Controllers
    {
        public class WorkoutController : Controller
        {
            private readonly IWorkoutService _workoutService;
            private readonly IExerciseService _exerciseService;
            private readonly UserManager<ApplicationUser> _userManager;
            public WorkoutController(UserManager<ApplicationUser> userManager, IWorkoutService workoutService,
                IExerciseService exerciseService)
            {
                _workoutService = workoutService;
                _exerciseService = exerciseService;
                _userManager = userManager;
            }

            [Authorize]
            public IActionResult Index(DateTime? selectedDate)
            {
                if (!selectedDate.HasValue || selectedDate == DateTime.MinValue)
                {
                    selectedDate = DateTime.Today;
                }
                var userId = _userManager.GetUserId(User);
                var model = _workoutService.GetWorkout(userId, selectedDate.Value);
                model.StartWorkout = selectedDate.Value;
                return View(model);
            }

            [HttpGet]
            public IActionResult AddWorkoutToDay(DateTime workoutData)
            {
                var model = new NewWorkoutVm();
                model.StartWorkout = workoutData;
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> AddWorkoutToDay(NewWorkoutVm model)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });
                }
                model.UserId = user.Id;
                var id = _workoutService.AddWorkout(model);

                DateTime workoutDate = model.StartWorkout;

                return RedirectToAction("Index", new { selectedDate = workoutDate });
            }

            [HttpGet]
            public IActionResult AddExerciseToWorkout(int workoutId)
            {
                var exercises = _exerciseService.GetAllExercisesForList(10, 1, "");
                var model = new NewWorkoutExerciseVm()
                {
                    Exercises = exercises.ExerciseForListVm,
                    WorkoutId = workoutId
                };
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> AddExerciseToWorkout(NewWorkoutExerciseVm model)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToPage("/Account/Login", new { area = "Identity" });
                }
                model.UserId = user.Id;

                var id = _workoutService.AddExerciseToWorkout(model);
                return RedirectToAction("Index");
            }

            public IActionResult DeleteWorkout(int workoutid, DateTime workoutData)
            {
                _workoutService.DeleteWorkout(workoutid);
                return RedirectToAction("Index", new { selectedDate = workoutData });
            }

            public IActionResult Delete(int id)
            {
                _workoutService.DeleteProduct(id);
                return RedirectToAction("Index");
            }

            public IActionResult Details(int id)
            {
                var model = _exerciseService.GetExerciseDetailByWorkoutExercise(id);
                return View(model);
            }

            [HttpGet]
            public IActionResult EditExercise2(int workoutId)
            {
                var exercise = _workoutService.GetWorkoutExerciseById(workoutId);
                return View(exercise);
            }

            [HttpPost]
            public IActionResult EditExercise2(NewWorkoutExerciseVm model)
            {
                var userId = _userManager.GetUserId(User);
                model.UserId = userId;
                _workoutService.UpdateExercise(model);
                return RedirectToAction("Index");
            }
        }
    }
}
