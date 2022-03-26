using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShorteningApi.Models
{
    public class PreviousDayAnalyticsModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public DateOnly dateOnly { get; set; }
        public DateTime date { get; set; }

        [Required]
        public string longUrl { get; set; }
   


    }
}
