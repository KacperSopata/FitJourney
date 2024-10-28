using ApplicationForTrainingWEB.Domain.Model;

namespace ApplicationForTrainingWEB.Domain.Interfaces;

public interface IPostRepository
{
    IQueryable<Post> GetAllPost();
    int AddPost(Post post);
    Post GetDetail(int id);
    void DeletePost(Post post);
}