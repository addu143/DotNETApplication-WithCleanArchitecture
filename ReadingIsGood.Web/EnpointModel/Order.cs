using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Web.EnpointModel
{
    public class OrderNewRequest
    {
        [Required, MinLength(1)]
        public OrderNewProductRequest[] Products { get; set; }
    }

    public class OrderNewProductRequest 
    {
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int ProductId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }

    }

}
