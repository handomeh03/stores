using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Stores.Models
{
    

    public class UserModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]

        public string Password { get; set; } = string.Empty;

        
        public string? RefreshToken { get; set; }

        public string? Image { get; set; }

        [Phone]
        [StringLength(50)]
        public string? Phone { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        public int RoleId { get; set; }
        public UserRole Role { get; set; } = null!;

        public ICollection<Order> Users { get; set; } = new List<Order>();


    }
}