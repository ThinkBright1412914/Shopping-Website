using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class Cart
    {
        public string Id { get; set; }  

        public string userId { get; set; }

        public IdentityUser User { get; set; }
        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }


    }
}
