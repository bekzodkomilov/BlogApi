using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Services
{
    public class PostService : IPostService
    {
        private readonly ApiContext _ctx;
        private readonly ILogger<PostService> _log;

        public PostService(ILogger<PostService> logger, ApiContext context)
        {
            _ctx = context;
            _log = logger;
        }
        public async Task<(bool IsSuccess, Exception Exception, Post Post)> CreateAsync(Post post)
        {
         try
        {
            await _ctx.Posts.AddAsync(post);
            await _ctx.SaveChangesAsync();

            _log.LogInformation($"Post create in DB: {post.Id}");

            return (true, null, post);
        }
        catch(Exception e)
        {
             _log.LogInformation($"Create post to DB failed: {e.Message}", e);
            return (false, e, null);
        }

        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
              if(!await ExistsAsync(id))
            {
                _log.LogInformation($"delete post to DB failed: {id}");

                return(false, new ArgumentException($"There is no Post with given Id: {id}"));
            }
            _ctx.Posts.Remove(await GetAsync(id));
            await _ctx.SaveChangesAsync();
            _log.LogInformation($"Post remove in DB: {id}");
           
            return (true, null);
        }

        public Task<bool> ExistsAsync(Guid id)
          => _ctx.Posts
        .AnyAsync(p => p.Id == id);

        public Task<List<Post>> GetAllAsync()
        => _ctx.Posts
            .AsNoTracking()
            .Include(m => m.Comments)
            .Include(m => m.Medias)
            .ToListAsync();
        public Task <Post> GetAsync(Guid id)
        => _ctx.Posts.FirstOrDefaultAsync(a => a.Id == id);
        

        public async Task<(bool IsSuccess, Exception Exception, Post Post)> UpdatePostAsync(Post post)
        {
                if(!await ExistsAsync(post.Id))
          {
            _log.LogInformation($"delete post to DB failed: {post.Id}");  
           
            return (false, new ArgumentException($"There is no Post with given ID: {post.Id}"), null);
          }

            await _ctx.Posts.AnyAsync( t => t.Id == post.Id);

            post.ModifiedAt = DateTimeOffset.UtcNow;

            _ctx.Posts.Update(post);
            await _ctx.SaveChangesAsync(); 
            _log.LogInformation($"Post update : {post.Id}");
            
            return(true, null, post);   
        }
    }
}