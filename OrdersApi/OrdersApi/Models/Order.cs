using Microsoft.AspNetCore.Mvc;
using OrdersApi.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace OrdersApi.Models
{
    public class Order
    {
        //private List<Product> _products = new List<Product>();
        public Guid OrderNumber = Guid.NewGuid();

        [Required(ErrorMessage = "OrderDate can't be blank")]
        public DateTime? OrderDate { get; set; }

        [FinalCartPriceValidator()]
        public double? InvoicePrice { get; set; }

        [MinimumProductValidator()] 
        public List<Product>? Products { get; set;}

        //TODO
        //VERIFICAR COMO VALIDAR A CLASSE COMPARANDO 2 ATRIBUTOS, PARA
        //QUE ASSIM SEJA VERIFICADO SE O VALOR TOTAL DO CART BATE COM A SOMA DOS PRODUTOS DO CART

        public JsonResult CreateOrder()
        {
            Dictionary<string, Guid> createdFeedback = new Dictionary<string, Guid>()
            {
                { "orderNumber", OrderNumber }
            };

            return new JsonResult(createdFeedback);

        }
    }
}
