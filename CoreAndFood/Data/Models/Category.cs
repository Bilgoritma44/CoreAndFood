using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAndFood.Data.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        [StringLength(20, ErrorMessage = "Lütfen 4-20 Aralıkları içinde Karakter Tanımlaması Yapınız...", MinimumLength = 4)]
        public string CategoryName { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez...")]
        public string CategoryDescription { get; set; }

        public List<Food> Foods { get; set; }
    }
}
