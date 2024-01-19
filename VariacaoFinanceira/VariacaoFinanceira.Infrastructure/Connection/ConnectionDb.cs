using System.Data;
using System.Data.SqlClient;

namespace VariacaoFinanceira.Infrastructure.Connection;

public class ConnectionDb
{
    public IDbConnection SqlConnection()
    {
        return new SqlConnection("Data Source=DESKTOP-SSE2VN1\\SQLEXPRESS01;Initial Catalog=VariacaofinanceiraDB;User ID=variacaoFinanceira;Password=123456; Trusted_Connection=True; MultipleActiveResultSets=True;TrustServerCertificate=true");
    }
}
