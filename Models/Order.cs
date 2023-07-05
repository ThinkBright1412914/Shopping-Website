using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Models
{
    public class Order
    {
        public String Id { get; set; }

        public string UserId { get; set; }
        
        public IdentityUser User { get; set; }

        public OrderStatus Status { get; set; }

        public string BillingAddressId {get; set; }

        public Address BillingAddress { get; set; }

    }


    public enum OrderStatus
    {
        Pending,
        Approved,
        Cancelled,
        Done
    }
}
