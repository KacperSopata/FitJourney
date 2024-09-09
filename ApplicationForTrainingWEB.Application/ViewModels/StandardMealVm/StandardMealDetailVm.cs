using ApplicationForTrainingWEB.Application.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.StandardMealVm
{
    public class StandardMealDetailVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Meal>
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float Grammage { get; set; }
        public List<StandardMealDetailVm> Products { get; set; }
        public List<StandardMealDetailVm> Meals { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Meal, StandardMealDetailVm>()
                    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.MealProducts));
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Product, StandardMealDetailVm>();
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.MealProduct, StandardMealDetailVm>()
                     .ForMember(dest => dest.Grammage, opt => opt.MapFrom(src => src.Grammage));

        }
    }
}