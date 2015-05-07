using System.Collections.Generic;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Models
{
    public class ShoppingCartModel
    {
        public ShoppingCartModel()
        {
            Products = new List<Product>();
        }

        public List<Product> Products { get; set; }
    }
}