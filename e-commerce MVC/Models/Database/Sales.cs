using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    [Table("sales")]
    public partial class Sales
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [Column("arrived", TypeName = "binary(1)")]
        public byte[] Arrived { get; set; }

        [ForeignKey("ProductId")]
        [InverseProperty("Sales")]
        public Products Product { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Sales")]
        public Users User { get; set; }
    }
}
