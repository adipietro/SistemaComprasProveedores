using System.Data;
using Microsoft.Data.SqlClient;

public class SQLfactory : ADOfactory
{
    public override SqlCommand CrearComando(SqlConnection pconexion, string pcommand)
    {
        var mcom = pconexion.CreateCommand();
        mcom.CommandText = pcommand;
        mcom.CommandType = CommandType.Text;

        return mcom;
    }

    public override SqlCommand CrearComando(SqlConnection pconexion, string pcommand, SqlParameter[] @params)
    {
        SqlCommand mcom = new SqlCommand();
        mcom.Connection = pconexion;
        mcom.CommandText = pcommand;
        mcom.CommandType = CommandType.Text;
        mcom.Parameters.AddRange(@params);

        return mcom;
    }

    public override SqlConnection CrearConexion()
    {
        SqlConnection cn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;");
        return cn;
    }
}
