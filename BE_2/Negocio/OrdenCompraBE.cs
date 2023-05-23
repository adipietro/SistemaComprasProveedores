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

public class OrdenCompraBE : ID
{
    public DateTime Fecha { get; set; }
    public ProveedorBE Proveedor { get; set; }
    public AreaBE Area { get; set; }
    public double Importe { get; set; }
    public string dvh { get; set; }
}
