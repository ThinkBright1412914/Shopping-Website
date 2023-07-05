using Ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.ViewModel
{
    public class OrderViewModel
    {
        public String Id { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public OrderStatus Status { get; set; }

        public string BillingAddressId { get; set; }

        public Address BillingAddress { get; set; }

        public List<OrderItem> Items { get; set; }
    }
}
