using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;

public class Conexion
{
    private static SqlConnection mConnection;

    public static DataSet ExecuteDataSet(string pcommand)
    {
        DataSet data = new DataSet();
        SQLfactory mfactory = new SQLfactory();

        DbConnection cn = mfactory.CrearConexion;
        DbCommand com = mfactory.CrearComando(cn, pcommand);
        SqlDataAdapter madapter = new SqlDataAdapter(com);

        try
        {
            cn.Open();
            madapter.Fill(data);
            return data;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error DataSet");
            Interaction.MsgBox(ex.Message);
            return null/* TODO Change to default(_) if this is not a reference type */;
        }
        finally
        {
            cn.Close();
        }
    }
    public static DataSet ExecuteDataSet(string pcommand, SqlParameter[] sqlparams)
    {
        DataSet data = new DataSet();
        SQLfactory mfactory = new SQLfactory();

        DbConnection cn = mfactory.CrearConexion;
        DbCommand com = mfactory.CrearComando(cn, pcommand, sqlparams);

        SqlDataAdapter madapter = new SqlDataAdapter(com);


        try
        {
            cn.Open();
            madapter.Fill(data);
            return data;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error DataSet");
            Interaction.MsgBox(ex.Message);
            return null/* TODO Change to default(_) if this is not a reference type */;
        }
        finally
        {
            cn.Close();
            com.Parameters.Clear();
        }
    }


    public static void ExecuteNonQuery(string pcommand, SqlParameter[] @params)
    {
        SQLfactory mfactory = new SQLfactory();

        DbConnection cn = mfactory.CrearConexion;
        DbCommand com = mfactory.CrearComando(cn, pcommand, @params);

        try
        {
            cn.Open();
            com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error NonQuery");
            Interaction.MsgBox(ex.Message);
        }
    }

    public static void ExecuteNonQuery(string pcommand)
    {
        SQLfactory mfactory = new SQLfactory();

        DbConnection cn = mfactory.CrearConexion;
        DbCommand com = mfactory.CrearComando(cn, pcommand);

        try
        {
            cn.Open();
            com.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error NonQuery");
            Interaction.MsgBox(ex.Message);
        }
    }


    public static SqlDataReader ExecuteReader(string pCommandStr)
    {
        SqlDataReader mReader;
        SQLfactory mfactory = new SQLfactory();

        try
        {
            DbConnection mConnection = mfactory.CrearConexion;
            DbCommand mCommand = mfactory.CrearComando(mConnection, pCommandStr);

            mConnection.Open();
            mReader = mCommand.ExecuteReader();

            return mReader;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - Reader - BD");
            Interaction.MsgBox(ex.Message);
            return null;
        }
        finally
        {
            mReader.Close();
            mConnection.Close();
            mConnection.Dispose();
        }
    }
    public static int ExecuteScalar(string pCommandStr, SqlParameter[] @params)
    {
        SQLfactory mfactory = new SQLfactory();
        try
        {
            DbConnection mConnection = mfactory.CrearConexion;
            DbCommand mCommand = mfactory.CrearComando(mConnection, pCommandStr, @params);

            mConnection.Open();
            return mCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - Scalar - BD");
            Interaction.MsgBox(ex.Message);
            return default(Integer);
        }
        finally
        {
        }
    }

    public static int ExecuteScalar(string pCommandStr)
    {
        SQLfactory mfactory = new SQLfactory();
        try
        {
            DbConnection mConnection = mfactory.CrearConexion;
            DbCommand mCommand = mfactory.CrearComando(mConnection, pCommandStr);

            mConnection.Open();
            return mCommand.ExecuteScalar();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - Scalar - BD");
            Interaction.MsgBox(ex.Message);
            return default(Integer);
        }
        finally
        {
        }
    }

    public static int UltimoID(string pTabla)
    {
        int mID;
        SQLfactory mfactory = new SQLfactory();

        try
        {
            DbConnection mConnection = mfactory.CrearConexion;
            SqlCommand mCommand = new SqlCommand("SELECT ISNULL(MAX(" + pTabla.ToLower() + "_id), 0) FROM " + pTabla, mConnection);

            mConnection.Open();
            mID = mCommand.ExecuteScalar();

            return mID;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - UltimoID - BD");
            Interaction.MsgBox(ex.Message);
            return default(Integer);
        }
        finally
        {
            mConnection.Close();
            mConnection.Dispose();
        }
    }
}
