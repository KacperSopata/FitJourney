using ApplicationForTrainingWEB.Application.Mapping;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.UserMealVm
{
    public class UserMealForListVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Meal>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ProductForListVm> Products { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Meal, UserMealForListVm>().ReverseMap();
        }
    }
}
