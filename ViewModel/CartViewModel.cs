using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.ViewModel
{
    public class CartViewModel
    {
        public string Id { get; set; }     
        public string ProductId { get; set; }

        public ProductViewModel Product { get; set; }

        public int Quantity { get; set; }
    }
}
