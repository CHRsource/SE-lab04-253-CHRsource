using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesAudios.Models
{
    public class Audio
    {
        public int Id { get; set; }


        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string Title { get; set; } = string.Empty;


        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string? Performer { get; set; }


		[Display(Name = "Release Date")]
		[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z\s&-]*$")]
        [Required]
        [StringLength(30)]
        public string? Genre { get; set; }


		[Display(Name = "Tracks Number")]
		public int TracksNumbers { get; set; }


		[Display(Name = "Total Duration")]
		[DisplayFormat(DataFormatString = "{0:hh\\:mm\\:ss}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "Enter the time in HH:MM:SS format")]
        public TimeSpan TotalDuration { get; set; }


        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; } = string.Empty;
    }
}
