using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class SigInInput
    {
        [Display(Name ="Email Adresiniz")]
        public string Email { get; set; }
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool IsRemember { get; set; }
    }
}