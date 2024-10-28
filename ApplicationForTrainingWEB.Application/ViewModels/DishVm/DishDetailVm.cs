using ApplicationForTrainingWEB.Application.Mapping;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.DishVm
{
    public class DishDetailVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Meal>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public float Grammage { get; set; }
        public DateTime Date { get; set; }
        public List<ListProducts> Products { get; set; }
        public List<ListProducts> Meals { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Meal, DishDetailVm>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.MealProducts));

            profile.CreateMap<Product, DishDetailVm>();

            profile.CreateMap<MealProduct, DishDetailVm>()
                .ForMember(dest => dest.Grammage, opt => opt.MapFrom(src => src.Grammage));
        }
    }
}
