using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models.NewDb
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Subject { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
    }
}