using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Catalogs
{
    public class CourseCreateInput
    {
        [Required]
        [Display(Name = "Kurs İsmi")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Kurs Fiyatı")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Kurs Resmi")]
        public string Picture { get; set; }
        [Display(Name = "Kurs Açıklama")]
        public string Description { get; set; }
        public string UserId { get; set; }
        [Required]
        [Display(Name = "Kurs Kategorisi")]
        public string CategoryId { get; set; }
        public FeatureViewModel Feature { get; set; }
        [Display(Name = "Kurs Resmi")]
        public IFormFile PhotoFormFile { get; set; }
    }
}