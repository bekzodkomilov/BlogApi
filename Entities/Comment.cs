using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Entities
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string Author { get; set; }

        public string Content { get; set; }

        public ECommentState State { get; set; }

        public Guid PostId { get; set; }
    }
}
