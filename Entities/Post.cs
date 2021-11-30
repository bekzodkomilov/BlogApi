using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class Post
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        public Guid HeaderImageId { get; set; }

        [MaxLength(255)]
        [Required]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public string Content { get; set; }

        public uint Viewed { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Media> Medias { get; set; }

        // [Obsolete("Warning")]
        // public Post() { }

        // public Post(string title, string description, string content, uint viewed, ICollection<Media> medias)
        // {
        //     Id = Guid.NewGuid();
        //     HeaderImageId= Guid.NewGuid();
        //     Title = title;
        //     Description = description;
        //     Content = content;
        //     Viewed = viewed;
        //     CreatedAt = DateTimeOffset.UtcNow;
        //     ModifiedAt = CreatedAt;
        //     Medias = medias;
        // }


    }
}
