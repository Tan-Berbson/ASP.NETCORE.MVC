using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace YAWA.COM.Data
{
    public class MontlyTask : BaseEntity
    {
        [Required, MaxLength(100)]
        public string DailyTaskName { get; set; }

        [Required, MaxLength(100)]
        public string TaskStatus { get; set; }

        [Required]
        public DateOnly StartDate { get; set; }

        [Required]
        public DateOnly EndDate { get; set; }

        [Required,MaxLength(100)]
        public string MontlyTaskCategory { get; set; }


    }
}

