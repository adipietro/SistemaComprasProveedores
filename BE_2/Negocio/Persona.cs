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

public class Persona : ID
{
    public string nombre { get; set; }
    public string Apellido { get; set; }

    public override string ToString()
    {
        return this.nombre + " " + this.Apellido;
    }
}
