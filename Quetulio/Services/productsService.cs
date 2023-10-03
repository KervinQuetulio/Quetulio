using Quetulio.Models;
using System.Data.SqlClient;

namespace Quetulio.Services
{
    public class productsService
    {
        private static string db_source = "quetulio.database.windows.net";

        private static string db_user = "appsdev_sa";

        private static string db_password = "Thr33c0m@12";

        private static string db_database = "quetuliodb";

        private SqlConnection GetConnection()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection( _builder.ConnectionString);
        }

        public  List<products> GetProducts()
        {
            SqlConnection conn= GetConnection();
            List<products> _productist = new List<products>();

            string statement = "select * from products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {  while(reader.Read())
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
