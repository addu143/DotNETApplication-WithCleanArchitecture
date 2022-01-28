using System.Collections.Generic;
using System.Linq;

namespace ReadingIsGood.Core.DBEntities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            this.OrderItems = new List<OrderItem>();
        }

        public double Total { get { return OrderItems.Sum(t => t.SubTotal); } set { } }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }

       

    }
    public enum OrderStatus
    {
        New,
        Pending,
        Delivered
    }
}
