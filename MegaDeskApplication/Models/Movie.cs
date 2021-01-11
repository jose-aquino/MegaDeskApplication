using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime QuoteDate { get; set; }

        public decimal QuotePrice { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal()")]
        public decimal Width { get; set; }
        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal()")]
        public decimal Length { get; set; }

        public int Drawers { get; set; }
        public string Delivery { get; set; }
        public string DesktopMaterial { get; set; }
        [Key]
        public int ID { get; set; }

    }
}
