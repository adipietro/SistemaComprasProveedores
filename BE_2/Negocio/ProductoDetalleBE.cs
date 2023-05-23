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

public class ProductoDetalleBE : ID
{
    public ProductoDetalleBE()
    {
    }

    public ProveedorBE Proveedor { get; set; }
    public ProductoBE Producto { get; set; }
    public double Precio { get; set; }
    public int DescuentoCantidad { get; set; }
    public int CantidadDescuento { get; set; }
}
