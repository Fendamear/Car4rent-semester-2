using System.Data;
using System.Data.SqlClient;


namespace Car4Rent.DAL
{
    public class DatabaseDAL
    {   //PC
        static string connectionstring = "Data Source=DESKTOP-PERRQVJ;Initial Catalog=Car4Rent Software sem 2;Integrated Security=True";
        //Laptop
        //static string connectionstring = @"Data Source=LAPTOP-RPKE8E4N\SQLEXPRESS;Initial Catalog=Car4Rent Software sem 2;Integrated Security=True";

        private SqlConnection _connection = new SqlConnection(connectionstring);

        

        public DatabaseDAL()
        {

        }

        public DataTable Query(SqlCommand query)
        {
            query.Connection = _connection;
            var table = new DataTable();
            var adapter = new SqlDataAdapter(query);

            _connection.Open();
            adapter.Fill(table);
            _connection.Close();
            query.Dispose();

            return table;
        }

        public void ExecuteQuery(SqlCommand query)
        {

            query.Connection = _connection;
            _connection.Open();

            query.ExecuteNonQuery();
            _connection.Close();
            query.Dispose();
        }

        public int GetMaxID(SqlCommand query, string column)
        {
            query.Connection = _connection;
            int id = 0;
            _connection.Open();
            using (SqlDataReader reader = query.ExecuteReader())
            {
                while (reader.Read())
                {
                    id = (int)reader[$"{column}"];
                }
            }
            _connection.Close();
            return id + 1;
        }

    }
}
