using System.ComponentModel.DataAnnotations;

namespace OrdersApi.Models
{
    public class Product
    {

        [Required(ErrorMessage = "ProductCode can't be blank")]
        public int ProductCode { get; set; }

        [Required(ErrorMessage = "Price can't be blank")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Quantity can't be blank")]
        public int Quantity { get; set; }   
    }
}
