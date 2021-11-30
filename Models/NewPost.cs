using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class NewPost
    {

    [MaxLength(255)]
    [Required]
    public string Title { get; set; }

    [MaxLength(255)]
    public string Description { get; set; }
    public string Content { get; set; }
    public uint Viewed { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset ModifiedAt { get; set; }
    // public ICollection<Comment> Comments { get; set; }
    public ICollection<Guid> HeaderImageId { get; set; }

    }
}