using ApplicationForTrainingWEB.Application.Mapping;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.WorkoutVm
{
    public class WorkoutDetailVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Exercise>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartWorkout { get; set; }
        public List<ExerciseForListVm> Exercises { get; set; }
        public List<WorkoutDetailVm> Workouts { get; set; } // Lista treningów
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Workout, WorkoutDetailVm>().ReverseMap();
            profile.CreateMap<Exercise, ExerciseForListVm>();
            profile.CreateMap<WorkoutExercise, WorkoutDetailVm>().ReverseMap();
        }
    }
}
