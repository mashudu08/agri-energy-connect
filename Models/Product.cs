using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agri_Energy_Connect.Models
{
    public class Product
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        [Required]
        [Column("name")]
        public string Name { get; set; }

        [Required]
        [Column("category")]
        public string Category { get; set; }

        [Required]
        [Column("production_date")]
        public DateOnly prodDate { get; set; }

        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }

    }
}
