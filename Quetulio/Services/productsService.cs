using Quetulio.Models;
using System.Data.SqlClient;

namespace Quetulio.Services
{
    public class productsService : IproductsService
    {
        private readonly IConfiguration _config;

        public productsService(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("SQLConnection"));
        }

        public List<products> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<products> _productist = new List<products>();

            string statement = "select * from products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products prd = new products()
                    {
                        ProductID = reader.GetInt32(0),

                        ProductName = reader.GetString(1),

                        Quantity = reader.GetInt32(2)
                    };
                    _productist.Add(prd);
                }
            }
            conn.Close();

            return _productist;





        }
    }
}
