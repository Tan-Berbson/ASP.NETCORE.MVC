using System.ComponentModel.DataAnnotations;

namespace YAWA.COM.Data
{
    public class LessonPlanner : BaseEntity
    {
        [Required, MaxLength(50)]
        public string LessonTittle { get; set; }

        [Required, MaxLength(100)]
        public string LessonName { get; set; }

        [Required, MaxLength(200)]
        public string LessonDescription { get; set; }
    }
}
