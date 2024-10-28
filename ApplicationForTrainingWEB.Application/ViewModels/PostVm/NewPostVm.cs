using ApplicationForTrainingWEB.Application.Mapping;
using ApplicationForTrainingWEB.Application.ViewModels.ReadyRecipesVm;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.ViewModels.PostVm
{
    public class NewPostVm : IMapFrom<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public IFormFile ImageContent { get; set; }
        public string UserId { get; set; }
        public string ApplicationUser { get; set; }
        public void ConfigureMapping(Profile profile)
        {
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Post, NewPostVm>();
            profile.CreateMap<NewPostVm, ApplicationForTrainingWEB.Domain.Model.Post>();
            profile.CreateMap<ApplicationForTrainingWEB.Domain.Model.Post, PostForListVm>();
        }
    }
}
