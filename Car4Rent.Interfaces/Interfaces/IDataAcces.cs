using System.Data;
using System.Data.SqlClient;

namespace Car4Rent.Interfaces.Interfaces
{
    public interface IDataAcces
    {
        public DataTable Query(SqlCommand query);
        public void ExecuteQuery(SqlCommand query);
        int ExecuteNonQuery(SqlCommand query);
    }
}
