using System.Collections.Generic;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Models
{
    public class ShoppingCartIndexViewMode
    {
        public IList<Product> Products { get; set; }
    }
}