using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace YAWA.COM.Data
{
    public class MontlyTask : BaseEntity
    {
        [Required, MaxLength(100)]
        public string MontlyTaskName { get; set; }
    }
}

