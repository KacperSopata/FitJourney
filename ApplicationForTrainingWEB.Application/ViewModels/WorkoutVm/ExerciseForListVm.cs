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
    public class ExerciseForListVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public float Weight { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Exercise, ExerciseForListVm>();
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.WorkoutExercise, ExerciseForListVm>()
                .ForMember(dest => dest.Sets, opt => opt.MapFrom(src => src.Sets))
                .ForMember(dest => dest.Reps, opt => opt.MapFrom(src => src.Reps))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Exercise.Name))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight));
        }
    }
}
