using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using YAWA.COM.Data;

namespace YAWA.Data
{
    public class Ipon : LessonPlanner
{
        [BindNever]
        [Required]
        public string userId { get; set; }

        [Key]
        [Required]
        public int IponId { get; set; }

        [Required,MaxLength(100)]
        public string ProjectIponName { get; set; }

        [Required] [MaxLength(100)]

        public string ProjectDescription { get; set; }
        [Required]
        public double IponTotalCost { get; set; }

        [Required, MaxLength(100)]

        public string IponNameName { get; set; }

        [Required]
        public double IponAdd { get; set; }
        

}
}
