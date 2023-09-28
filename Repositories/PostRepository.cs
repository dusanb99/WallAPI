using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using WallAPI.DTO;
using WallAPI.Models;
using WallAPI.Repositories.Interfaces;

namespace WallAPI.Repositories
{
    public class PostRepository : IPostRepository
    {

        public readonly WallDbContext _context;

        public PostRepository(WallDbContext context)

        {
            _context = context;
        }

        public async Task CreatePost(Post post)
        {
           await _context.Posts.AddAsync(post);
           await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetAllPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        public async Task DeleteOnePost(Post post)
        {
            _context.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<Post> GetOnePost(int id)
        {
            return await _context.Posts.Where(p=> p.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdatePost(Post post)
        {
            _context.Update(post);
            await _context.SaveChangesAsync();
        }

    }
}
