using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BookInventory.Models
{
    public class Book
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string? Title { get; set; } = string.Empty;
        [StringLength(60)]
        public string? Author { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime PublishDate { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string? Genre { get; set; } = string.Empty;
        public double Isbn { get; set; } = 0;
    }
}
