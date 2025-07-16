using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BusinessObjects.Entities
{
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string AccountName { get; set; }

        // Foreign key
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        [JsonIgnore]
        public virtual Role? Role { get; set; }
    }
}