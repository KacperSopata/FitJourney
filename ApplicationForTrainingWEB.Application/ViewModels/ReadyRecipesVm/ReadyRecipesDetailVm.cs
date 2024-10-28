using ApplicationForTrainingWEB.Application.Mapping;
using ApplicationForTrainingWEB.Application.ViewModels.PostVm;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.ReadyRecipesVm
{
    public class ReadyRecipesDetailVm : IMapFrom<ApplicationForTrainingWEB.Domain.Model.ReadyRecipes>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public byte[] Image { get; set; } // Obecny obraz
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.ReadyRecipes, ReadyRecipesDetailVm>();
        }
    }
}
