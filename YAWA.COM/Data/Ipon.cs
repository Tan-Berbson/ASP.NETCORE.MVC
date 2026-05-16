using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace YAWA.COM.Data
{
    public class Ipon : BaseEntity
    {
        [Required, MaxLength(100)]
        public string ProjectIponName { get; set; }

        [Required, MaxLength(100)]
        public string ProjectDescription { get; set; }

        [Required]
        public double IponTotalCost { get; set; }

        [Required, MaxLength(100)]
        public string IponNameName { get; set; }

        [Required]
        public double IponAdd { get; set; }
    }
}

