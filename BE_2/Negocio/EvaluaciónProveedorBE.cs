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

public class EvaluaciónProveedorBE : ID
{
    public ProveedorBE Proveedor { get; set; }
    public int CalificacionTiempos { get; set; }
    public int CalificacionAtencion { get; set; }
    public int CalificacionComunicacion { get; set; }
    public int CalificacionCalidad { get; set; }
    public int Cantidad { get; set; }
    public string Fecha { get; set; }


    public double Promedio()
    {
        var prom = ((CalificacionTiempos + CalificacionComunicacion + CalificacionCalidad + CalificacionAtencion) / (double)4);
        return prom;
    }
}

