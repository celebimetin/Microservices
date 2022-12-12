using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs Süresi")]
        public int Duration { get; set; }
    }
}