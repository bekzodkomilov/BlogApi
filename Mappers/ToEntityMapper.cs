using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Mappers
{
    public static class ToEntityMapper
    {
        // public static Entities.Post
        // ToPostEntity( this Models.NewPost newPost,IEnumerable<Entities.Media> media)
        // {

        //     return new Entities.Post(title: newPost.Title,
        //         description: newPost.Description,
        //         content: newPost.Content,
        //         viewed: newPost.Viewed,
        //         medias : media.ToList()
        //       );
        // } 

        //    ToGetEntity( this Models.GetPost newPost,IEnumerable<Entities.Comment> comment)
        // {

        //     return new Entities.Post(title: newPost.Title,
        //         description: newPost.Description,
        //         content: newPost.Content,
        //         viewed: newPost.Viewed,
        //       );
        // } 
        
         public static Entities.Post ToPostEntity(this Models.NewPost post, 
        IEnumerable<Entities.Media> media)
            => new Entities.Post()
            {
                Id = Guid.NewGuid(),
                HeaderImageId=Guid.NewGuid(),
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                Viewed = post.Viewed,
                CreatedAt=DateTimeOffset.UtcNow,
                ModifiedAt=post.CreatedAt,
                Medias = media.ToList()
            };
    
       
    }
}
