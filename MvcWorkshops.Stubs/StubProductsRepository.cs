using System.Collections.Generic;
using System.Linq;
using MvcWorkshops.Repository;

namespace MvcWorkshops.Stubs
{
    public class StubProductsRepository : IRepository<Product>
    {
        private static IList<Product> _products = new List<Product>();

        static StubProductsRepository()
        {
            Enumerable.Range(1, 100).ToList().ForEach(x =>
            {
                _products.Add(new Product
                {
                    Name = "Product" + x,
                    ImageUrl = "Product.jpg",
                    Price = decimal.Multiply(5, 85*x)
                });
            });
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public void Save(Product news)
        {
            throw new System.NotImplementedException();
        }
    }
}