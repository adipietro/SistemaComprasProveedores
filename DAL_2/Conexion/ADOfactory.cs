using System.Data.SqlClient;
using System.Data.Common;


public abstract class ADOfactory
{
    public abstract SqlConnection CrearConexion();

    public abstract DbCommand CrearComando(DbConnection pconexion, string pcommand);
    public abstract System.Data.Common.DbCommand CrearComando(System.Data.Common.DbConnection pconexion, string pcommand, SqlParameter[] @params);
}
 