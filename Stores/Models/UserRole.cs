using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stores.Models
{
    public class UserRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {  get; set; }

        [Required]
        public string RoleName { get; set; } = string.Empty;

        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();
    }
}
