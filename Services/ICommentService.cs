using System;
using System.Threading.Tasks;
using api.Entities;

namespace api.Services
{
    public interface ICommentService
    {
    Task<(bool IsSuccess, Exception Exception, Comment Comment)> CreateAsync(Comment comment);
    Task<Comment> GetAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception, Comment Comment)> UpdateCommentAsync(Comment comment);
    Task<bool> ExistsAsync(Guid id);
    Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id);
    }
}