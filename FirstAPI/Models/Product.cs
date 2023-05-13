using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Models
{
    public class Product
    {

        public int Id { get; set; }
        [MinLength(3,ErrorMessage ="Inbvalid entry for name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Quantity has to be provided")]
        [Range(1,100,ErrorMessage ="Invalid number for quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(1,1000)]
        public float Price { get; set; }
    }
}
