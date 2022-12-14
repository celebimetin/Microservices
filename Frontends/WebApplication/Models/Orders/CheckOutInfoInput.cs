using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models.Orders
{
    public class CheckoutInfoInput
    {
        //Adress
        [Display(Name = "İl")]
        public string Province { get; set; }
        [Display(Name = "İlçe")]
        public string District { get; set; }
        [Display(Name = "Cadde")]
        public string Street { get; set; }
        [Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }
        [Display(Name = "Adres")]
        public string Line { get; set; }

        //Payment
        [Display(Name = "Kart İsim Soyisim")]
        public string CardName { get; set; }
        [Display(Name = "Kart numarası")]
        public string CardNumber { get; set; }
        [Display(Name = "Son kullanım tarihi(Ay/Yıl)")]
        public string Expiration { get; set; }
        [Display(Name = "CVV / CVC2 numarası")]
        public string CVV { get; set; }
    }
}