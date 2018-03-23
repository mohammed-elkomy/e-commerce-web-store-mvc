using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.Database
{
    [Table("messages")]
    public class Messages
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("sender_name")]
        [StringLength(50)]
        public string SenderName { get; set; }
        [Required]
        [Column("sender_email")]
        [StringLength(50)]
        public string SenderEmail { get; set; }
        [Required]
        [Column("subject")]
        [StringLength(30)]
        public string Subject { get; set; }
        [Required]
        [Column("message", TypeName = "text")]
        public string Message { get; set; }
        [Required]
        [Column("readed", TypeName = "binary(1)")]
        public byte[] Readed { get; set; }
    }
}
