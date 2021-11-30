using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Services
{
    public class MediaService : IMediaService
    {
        private readonly ApiContext _ctx;
        private readonly ILogger<MediaService> _log;

        public MediaService(ILogger<MediaService> logger, ApiContext context)
        {
            _ctx = context;
            _log = logger;
        }
        public async Task<(bool IsSuccess, Exception Exception,List<Media> Media)> CreateMediaAsync(List<Media> media)
        {
        try
        {
            await _ctx.Medias.AddRangeAsync(media);
            await _ctx.SaveChangesAsync();
              _log.LogInformation($"Media create in DB: {media}");
            return (true, null,media);
        }
        catch(Exception e)
        {
           _log.LogInformation($"Media post to DB failed: {e.Message}", e);
            return (false, e,null);
        }
        }

        public async Task<Media> GetAsync(Guid id)
         => await _ctx.Medias.FirstOrDefaultAsync(i => i.Id == id);
        public Task<List<Media>> GetAllAsync()
        => _ctx.Medias
            .AsNoTracking()
            .ToListAsync();

        public Task<bool> ExistsAsync(Guid id)
         => _ctx.Medias.AnyAsync(i => i.Id == id);

          public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid id)
        {
              if(!await ExistsAsync(id))
            {
                _log.LogInformation($"delete media to DB failed: {id}");

                return(false, new ArgumentException($"There is no Media with given Id: {id}"));
            }
            _ctx.Medias.Remove(await GetAsync(id));
            await _ctx.SaveChangesAsync();
            _log.LogInformation($"Media remove in DB: {id}");
           
            return (true, null);
        }
    }
}