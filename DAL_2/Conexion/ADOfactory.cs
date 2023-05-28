using System.Data.SqlClient;
using System.Data.Common;
using Microsoft.Data.SqlClient;

public abstract class ADOfactory
{
    public abstract SqlConnection CrearConexion();

    public abstract SqlCommand CrearComando(SqlConnection pconexion, string pcommand);
    public abstract SqlCommand CrearComando(SqlConnection pconexion, string pcommand, SqlParameter[] @params);
}
 