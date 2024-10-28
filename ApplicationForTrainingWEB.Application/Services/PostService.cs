using ApplicationForTrainingWEB.Application.Interfaces;
using ApplicationForTrainingWEB.Application.ViewModels.PostVm;
using ApplicationForTrainingWEB.Application.ViewModels.ReadyRecipesVm;
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

        public void DeletePost(int id)
        {
            var recipe = _postRepo.GetDetail(id);

            if (recipe != null)
            {
                _postRepo.DeletePost(recipe); // Wywołaj metodę usuwającą w repozytorium
            }
        }

        public ListPost GetAllPostForList(int pageSize, int pageNo, string searchString)
        {
            var readpostsQuery = _postRepo.GetAllPost();


            if (!string.IsNullOrEmpty(searchString))
            {
                readpostsQuery = readpostsQuery
                    .AsEnumerable()
                    .Where(r => r.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                    .AsQueryable();
            }

            var post = readpostsQuery
                .ProjectTo<PostForListVm>(_mapper.ConfigurationProvider)
                .ToList();

            var readyPostList = new ListPost
            {
                Posts = post.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList(),
                CurrentPage = pageNo,
                PageSize = pageSize,
                Count = post.Count,
                SearchString = searchString
            };

            return readyPostList;
        }

        public PostDetailVm GetPostDetail(int id)
        {
            var readyPostDetails = _postRepo.GetDetail(id);
            var readyPostDetailsVm = _mapper.Map<PostDetailVm>(readyPostDetails);
            return readyPostDetailsVm;
        }
    }
}