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

[Serializable]
public class ProveedorBE : ID
{
    public string CUIT { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public Cuidad Ciudad { get; set; }
    public Provincia Provincia { get; set; }
    public Pais Pais { get; set; }
    public string Telefono { get; set; }
    public string Celular { get; set; }
    public string CorreoElectronico { get; set; }




    public override string ToString()
    {
        return this.Nombre;
    }


    public ProveedorBE()
    {
    }
}
