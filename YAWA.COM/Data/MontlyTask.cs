using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace YAWA.COM.Data
{
    public class MontlyTask : LessonPlanner
{
    [BindNever]
    [Required, MaxLength(450)]
    public string? userid { get; set; }

    [Key]
    [Required]
    public int montlyTaskId { get; set; }

    [Required, MaxLength(100)]
    public string MontlyTaskName { get; set; }
}
}
