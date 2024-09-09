using ApplicationForTrainingWEB.Application.Mapping;
using ApplicationForTrainingWEB.Application.ViewModels.StandardMealVm;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.UserMealVm
{
    public class UserMealDetailVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Meal>
    {
        public DateTime Data { get; set; }
        public List<UserMealForListVm> Meals { get; set; }
  
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Meal, UserMealDetailVm>().ReverseMap();
            profile.CreateMap<Product, ProductForListVm>();
            profile.CreateMap<MealProduct, UserMealDetailVm>().ReverseMap();
        }
    }
}
                                        