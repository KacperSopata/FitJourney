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
    public class NewWorkoutExerciseVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.WorkoutExercise>
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int WorkoutId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public string ApplicationUser { get; set; }
        public string UserId { get; set; }
        public List<ExerciseVm.ExerciseForListVm> Exercises { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.WorkoutExercise, NewWorkoutExerciseVm>();
            profile.CreateMap<NewWorkoutExerciseVm, WorkoutExercise>()
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
                .ForMember(dest => dest.Reps, opt => opt.MapFrom(src => src.Reps))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.WorkoutId, opt => opt.MapFrom(src => src.WorkoutId))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
        }
    }
}
