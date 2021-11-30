using System;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApiContext _ctx;
        private ILogger<CommentService> _log;

        public CommentService(ILogger<CommentService> logger, ApiContext context)
        {
            _ctx = context;
            _log = logger;
        }
        public async Task<(bool IsSuccess, Exception Exception, Comment Comment)> CreateAsync(Comment comment)
        {
        
        try
        {
            await _ctx.Comments.AddAsync(comment);
            await _ctx.SaveChangesAsync();
            
             _log.LogInformation($"create comment : {comment.Id}");
            return (true, null, comment);
        }
        catch(Exception e)
        {
          _log.LogInformation($"create comment to DB failed: {comment.Id}");  
            return (false, e, null);
        }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
             try
        {
            var comment = await GetAsync(id);

            if(comment == default(Comment))
            {
                return (false, new Exception("Not found"));
            }

            _ctx.Comments.Remove(comment);
            await _ctx.SaveChangesAsync();

            return (true,  null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
        }

        public Task<bool> ExistsAsync(Guid id)
         => _ctx.Comments.AnyAsync(a => a.Id == id);
       
        public Task<Comment> GetAsync(Guid id)
        => _ctx.Comments.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<(bool IsSuccess, Exception Exception, Comment Comment)> UpdateCommentAsync(Comment comment)
        {
             if(!await ExistsAsync(comment.Id))
          {
            _log.LogInformation($"update comment to DB failed: {comment.Id}");  
           
            return (false, new ArgumentException($"There is no Comment with given ID: {comment.Id}"), null);
          }

            await _ctx.Posts.AnyAsync( t => t.Id == comment.Id);

            _ctx.Comments.Update(comment);
            await _ctx.SaveChangesAsync(); 
            _log.LogInformation($"Comennt update : {comment.Id}");
            
            return(true, null, comment);   
        }
        
    }
}