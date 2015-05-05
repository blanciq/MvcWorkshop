using System.Collections.Generic;
using System.Data.SqlClient;

namespace MvcWorkshops.Repository
{
    public class NewsRepository : IRepository<News>
    {
        private readonly string _connectionString;

        public NewsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<News> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from dbo.News";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new News
                    {
                        Id = (int) reader["id"],
                        Content = (string) reader["content"]
                    };
                }
            }
        }

        public void Save(News news)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into dbo.News values (@p1)";
                cmd.Parameters.AddWithValue("@p1", news.Content);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
