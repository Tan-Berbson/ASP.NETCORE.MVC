using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YAWA.COM.Data
{
    public abstract class BaseEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

        [BindNever]
        [MaxLength(450)]
        public string? UserId { get; set; }
    }
}
