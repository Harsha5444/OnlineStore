using System.Configuration;
using System.Data.SqlClient;

public class ConnectionDAL
{
    protected string ConnectionString;

    public ConnectionDAL()
    {
        ConnectionString = ConfigurationManager.ConnectionStrings["ChoiceCon"].ConnectionString;
    }
    protected SqlConnection GetConnection()
    {
        return new SqlConnection(ConnectionString);
    }
}
