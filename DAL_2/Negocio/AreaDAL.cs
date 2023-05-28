using Microsoft.VisualBasic;
using System.Data;

public class AreaDAL
{
    public static AreaBE DataRowToAreaBE(DataRow pRow)
    {
        AreaBE areaBE = new AreaBE();
        areaBE.Id = Convert.ToInt32(pRow["Id_Area"]);
        areaBE.Nombre = pRow["NombreArea"].ToString();

        return areaBE;
    }

    public static AreaBE ObtenerArea(int ID)
    {
        AreaBE AreaBE = new AreaBE();
        string mCommand = "SELECT * FROM Area WHERE Id_Area = ID";

        try
        {
            DataSet mDataSet = Conexion.ExecuteDataSet(mCommand);

            if (mDataSet != null & mDataSet.Tables.Count > 0 & mDataSet.Tables[0].Rows.Count > 0)
            {
                AreaBE = DataRowToAreaBE(mDataSet.Tables[0].Rows[0]);
                return AreaBE;
            }
            else
                return null/* TODO Change to default(_) if this is not a reference type */;
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - DataSet - AreaDAL");
            Interaction.MsgBox(ex.Message);
            return null/* TODO Change to default(_) if this is not a reference type */;
        }
    }

    public static void GuardarNuevo(AreaBE areaBE)
    {
        string mCommand = string.Empty;


        mCommand = "INSERT INTO Area (NombreArea) VALUES ('" + areaBE.Nombre + "'); SELECT @@Identity";

        try
        {
            Conexion.ExecuteNonQuery(mCommand);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - Nuevo - AreaDAL");
            Interaction.MsgBox(ex.Message);
        }
    }

    public static void GuardarModificacion(AreaBE areaBE)
    {
        string mCommand = string.Empty;

        mCommand = "UPDATE Area SET NombreArea = '" + areaBE.Nombre + "' WHERE Id_Area = " + areaBE.Id + "UPDATE Empleado SET NombreArea = '" + areaBE.Nombre + "' WHERE Id_Area = " + areaBE.Id;
        try
        {
            Conexion.ExecuteNonQuery(mCommand);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - Modificacion - AreaDAL");
            Interaction.MsgBox(ex.Message);
        }
    }

    public static void Eliminar(AreaBE AreaBE)
    {
        string mCommand = "DELETE FROM Area WHERE Id_Area = " + AreaBE.Id;

        try
        {
            Conexion.ExecuteNonQuery(mCommand);
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - Eliminacion - AreaDAL");
            Interaction.MsgBox(ex.Message);
        }
    }

    public static List<AreaBE> Listar(int ID = -1)
    {
        List<AreaBE> mLista = new List<AreaBE>();
        string mCommand = string.Empty;
        DataSet mDataSet;

        try
        {
            if (ID != -1)
            {
                mCommand = "SELECT * FROM Area WHERE Id_Area = " + ID.ToString();
                mDataSet = Conexion.ExecuteDataSet(mCommand);
            }
            else
            {
                mCommand = "SELECT * FROM Area";
                mDataSet = Conexion.ExecuteDataSet(mCommand);
            }

            if (mDataSet != null & mDataSet.Tables.Count > 0 & mDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow mRow in mDataSet.Tables[0].Rows)
                {
                    AreaBE Area = new AreaBE();

                    Area = DataRowToAreaBE(mRow);

                    mLista.Add(Area);
                }

                return mLista;
            }
            else
                return new List<AreaBE>();
        }
        catch (Exception ex)
        {
            Interaction.MsgBox("Error - Listar - AreaDAL");
            Interaction.MsgBox(ex.Message);
            return null;
        }
    }
}
