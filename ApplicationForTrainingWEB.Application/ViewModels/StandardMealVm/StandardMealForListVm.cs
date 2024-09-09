using ApplicationForTrainingWEB.Application.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.StandardMealVm
{
    public class StandardMealForListVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Meal>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Data { get; set; }
        public List<StandardMealDetailVm> Products { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Meal, StandardMealForListVm>()
                    .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.MealProducts.Select(mp => mp.Product)));
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Meal, StandardMealForListVm>();
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.MealProduct, StandardMealForListVm>();
        }
    }
}
