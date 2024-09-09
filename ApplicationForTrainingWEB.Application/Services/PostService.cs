using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.ViewModels.PostVm;
using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Domain.Model;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationForTrainingWEB.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepo;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepo = postRepository;
            _mapper = mapper;
        }
        public int AddPost(NewPostVm model)
        {
            var post = _mapper.Map<Post>(model);
            if (model.ImageContent != null)
            {
                post.Image = model.Image;
            }
            var id = _postRepo.AddPost(post);
            return id;
        }

        public ListPost GetAllPostForList(int pageSize, int pageNO, string searchString)
        {
            var products = _postRepo.GetAllPost().Where(p => p.Title.StartsWith(searchString))
                       .ProjectTo<ApplicationForTrainingWEB.Application.ViewModels.PostVm.PostForListVm>(_mapper.ConfigurationProvider).ToList();
            var postToShow = products.Skip(pageSize * (pageNO - 1)).Take(pageSize).ToList();
            var postList = new ListPost()
            {
                PageSize = pageSize,
                CurrentPage = pageNO,
                SearchString = searchString,
                Posts = postToShow,
                Count = products.Count
            };
            return postList;
        }

        public PostDetailVm GetPostDetail(int id)
        {
            var postDetails = _postRepo.GetDetail(id);
            var postDetailsVm = _mapper.Map<PostDetailVm>(postDetails);
            return postDetailsVm;
        }
    }
}