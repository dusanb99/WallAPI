﻿using Microsoft.EntityFrameworkCore;
using WallAPI.Models;
using WallAPI.Repositories.Interfaces;

namespace WallAPI.Repositories
{
    public class CommentRepository : ICommentRepository
    {

        public readonly WallDbContext _context;



        public CommentRepository(WallDbContext context)

        {
            _context = context;
        }

        public async Task CreateComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetAllCommentsOfOnePost(int postId)
        {
            return await _context.Comments.Where(c => c.OriginPostId == postId).ToListAsync();
        }

        public async Task DeleteOneComment(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> GetOneComment(int id)
        {
            return await _context.Comments.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateComment(Comment comment)
        {
            _context.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsMyPost(int postId, string username)
        {
            var tempPost = await _context.Posts.Where(p => p.CreatorUsername == username && p.Id == postId).FirstOrDefaultAsync();
            if (tempPost != null)
            {
                return true;
            }
            return false;
        }


    }
}
