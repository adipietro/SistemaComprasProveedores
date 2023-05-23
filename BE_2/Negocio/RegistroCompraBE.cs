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

public class RegistroCompraBE : ID
{
    public ProductoBE producto { get; set; }
    public double PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
    public double Descuento { get; set; }
    public double PrecioTotal { get; set; }
    public OrdenCompraBE OrdenCompra { get; set; }
}
