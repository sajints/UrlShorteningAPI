using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShorteningApi.Models
{
    public class ShortUrlMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string token { get; set; }

        [Required]
        public string longUrl { get; set; }
        [Required]
        public string shortUrl { get; set; }

    }
}
