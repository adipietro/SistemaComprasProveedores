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

public class Cuidad : ID
{
    public string Nombre { get; set; } = string.Empty;
    public string CP { get; set; } = string.Empty;

    public Provincia Provincia { get; set; }

    public override string ToString()
    {
        return this.Nombre + " (CP: " + this.CP + ")";
    }

}
