using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace api.Models
{
    public class NewMedia
    {  
    
    // [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    // public Guid Id { get; set; }

    // [Required]
    // [MaxLength(50)]
    // public string ContentType { get; set; }   
    public IEnumerable<IFormFile> Data { get; set; }
        
    }
}