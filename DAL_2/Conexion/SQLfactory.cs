
using static Azure.Core.HttpHeader;
using System.Data;

public class SQLfactory : ADOfactory
{
    public override DbCommand CrearComando(DbConnection pconexion, string pcommand)
    {
        var mcom = pconexion.CreateCommand();
        mcom.CommandText = pcommand;
        mcom.CommandType = CommandType.Text;

        return mcom;
    }

    public override System.Data.Common.DbCommand CrearComando(System.Data.Common.DbConnection pconexion, string pcommand, SqlParameter[] @params)
    {
        SqlCommand mcom = new SqlCommand();
        mcom.Connection = pconexion;
        mcom.CommandText = pcommand;
        mcom.CommandType = CommandType.Text;
        mcom.Parameters.AddRange(@params);

        return mcom;
    }

    public override DbCommand CrearComando(DbConnection pconexion, string pcommand, SqlParameter[] @params)
    {
        throw new NotImplementedException();
    }

    public override DbCommand CrearComando(DbConnection pconexion, string pcommand, SqlParameter[] @params)
    {
        throw new NotImplementedException();
    }

    public override System.Data.SqlClient.SqlConnection CrearConexion()
    {
        SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("MiConexion").ConnectionString);
        return cn;
    }
}
