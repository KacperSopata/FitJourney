using ApplicationForTrainingWEB.Application.Mapping;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.ProductVm
{
    public class ProductForListVM : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Product>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Product, ApplicationForTrainingWEB.Application.ViewModels.ProductVm.ProductForListVM>(); //w nawiasach pierwsze to zrodlo drugie to destynacja. J
        }

    }
}
