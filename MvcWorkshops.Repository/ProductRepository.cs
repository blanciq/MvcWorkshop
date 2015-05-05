using System.Collections.Generic;
using System.Data.SqlClient;

namespace MvcWorkshops.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Product> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from dbo.Product";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new Product
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Description = (string)reader["description"],
                        ImageUrl = (string)reader["imageurl"],
                        Price = (decimal)reader["price"],
                    };
                }
            }
        }

        public void Save(Product news)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into dbo.News values (@p1, @p2, @p3, @p4)";
                cmd.Parameters.AddWithValue("@p1", news.Name);
                cmd.Parameters.AddWithValue("@p2", news.Description);
                cmd.Parameters.AddWithValue("@p3", news.ImageUrl);
                cmd.Parameters.AddWithValue("@p4", news.Price);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
