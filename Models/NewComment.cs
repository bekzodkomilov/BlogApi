using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class NewComment
    {
        [MaxLength(255)]
        public string Author { get; set; }

        public string Content { get; set; }

        public ECommentState State { get; set; }

        public Guid PostId { get; set; }
    }
}
