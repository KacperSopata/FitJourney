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
    public class UserNewMealVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.Meal>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Data { get; set; }
        public string ApplicationUser { get; set; }
        public string UserId { get; set; }

        public List<ProductForListVm> Products { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<Meal, UserNewMealVm>().ReverseMap();

        }
    }
}
