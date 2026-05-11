using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YAWA.COM.Data
{
    public class LessonPlanner
    {
        //foriegn key sa asp.netUser
        [ForeignKey("UserId")]
        public IdentityUser? user { get; set; }

        //Authentication 
        [BindNever]
        [MaxLength(450)]
        public string? UserId { get; set; }

        //Database Table for LessonPlanner
        [Key]
        [Required]
        public int LessonId { get; set; }

        [Required, MaxLength(50)]
        public string LessonTittle { get; set; }

        [Required, MaxLength(100)]
        public string LessonName { get; set; }

        [Required, MaxLength(200)]
        public string LessonDescription { get; set; }



    }
}
