using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace YAWA.COM.Data
{
    public class LessonPlanner
    {
        //Authentication 
        [BindNever]
        [MaxLength(500)]
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
