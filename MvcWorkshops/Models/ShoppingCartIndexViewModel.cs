using System.Collections.Generic;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Models
{
    public class ShoppingCartIndexViewModel
    {
        public IList<Product> Products { get; set; }
    }
}