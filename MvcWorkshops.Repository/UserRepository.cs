using System.Collections.Generic;
using System.Data.SqlClient;

namespace MvcWorkshops.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from [User]";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    yield return new User
                    {
                        Id = (int) reader["id"],
                        Username = (string) reader["username"],
                        Password = (string) reader["password"]
                    };
                }
            }
        }

        public void Save(User news)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "Insert into [User] values (@p1, @p2)";
                cmd.Parameters.AddWithValue("@p1", news.Username);
                cmd.Parameters.AddWithValue("@p2", news.Password);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
