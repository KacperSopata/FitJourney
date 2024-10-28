using ApplicationForTrainingWEB.Application.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.ExerciseVm
{
    public class ExerciseForListVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Exercise>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Exercise, ExerciseForListVm>();
        }
    }
}
