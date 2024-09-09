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
    public class ProductForListVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Grammage { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Product, ProductForListVm>().ReverseMap();
            profile.CreateMap<MealProduct, ProductForListVm>()
                .ForMember(dest => dest.Grammage, opt => opt.MapFrom(src => src.Grammage))
                .ReverseMap();

        }
    }
}
