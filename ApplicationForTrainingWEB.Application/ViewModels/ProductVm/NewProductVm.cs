using ApplicationForTrainingWEB.Application.Mapping;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.ProductVm
{
    public class NewProductVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Product> 
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public int Calories { get; set; }
        public float Protein { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public string UserId { get; set; }
        public string ApplicationUser { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Product, NewProductVm>().ReverseMap();
        }
        public class NewProductValidator : AbstractValidator<NewProductVm>
        {
            public NewProductValidator()
            {
                // RuleFor(x => x.Name).MaximumLength(5);
            }
        }
    }
}
