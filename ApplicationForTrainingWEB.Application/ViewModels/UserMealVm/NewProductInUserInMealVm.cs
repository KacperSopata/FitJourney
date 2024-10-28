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
    public class NewProductInUserInMealVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.MealProduct>
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int MealId { get; set; }
        public float Grammage { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public string ApplicationUser { get; set; }
        public string UserId { get; set; }
        public List<ProductVm.ProductForListVM> Products { get; set; }
        public void ConfigureMapping(Profile profile)
        {

            profile.CreateMap<MealProduct, NewProductInUserInMealVm>();
            profile.CreateMap<NewProductInUserInMealVm, MealProduct>()
                .ForMember(dest => dest.MealsId, opt => opt.MapFrom(src => src.MealId))
                .ForMember(dest => dest.ProductsId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Grammage, opt => opt.MapFrom(src => src.Grammage))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ReverseMap();
            profile.CreateMap<Product, NewProductInUserInMealVm>()
                .ForMember(dest => dest.Calories, sou => sou.MapFrom(src => src.Calories))
                .ForMember(dest => dest.Protein, sou => sou.MapFrom(src => src.Protein))
                .ForMember(dest => dest.Fat, sou => sou.MapFrom(src => src.Fat))
                .ForMember(dest => dest.Carbohydrates, sou => sou.MapFrom(src => src.Carbohydrates));
        }
    }
}
