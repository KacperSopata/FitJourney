using ApplicationForTrainingWEB.Domain.Interfaces;
using ApplicationForTrainingWEB.Domain.Model;
using ApplicationForTrainingWEB.Infrastructure;

namespace ApplicationForTrainingWEB.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly ApplicationForTrainingWEBDbContext _context;

    public PostRepository(ApplicationForTrainingWEBDbContext context)
    {
        _context = context;
    }
    public int AddPost(Post post)
    {
        post.ApplicationUser = _context.ApplicationUsers.Find(post.UserId);
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post.Id;
    }
    public void DeletePost(Post post)
    {
        _context.Posts.Remove(post);
        _context.SaveChanges();
    }
    public IQueryable<Post> GetAllPost()
    {
        var posts = _context.Posts.AsQueryable();
        return posts;
    }
    public Post GetDetail(int id)
    {
        return _context.Posts.FirstOrDefault(e => e.Id == id);
    }
}