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
using System.Windows.Forms;

public abstract class PatenteAbsBE : ID
{
    public string nombre { get; set; }


    public override string ToString()
    {
        return this.nombre;
    }

    public abstract bool Permite(string formulario);
    public abstract HashSet<PatenteBE> ListarPatentesHojasPermitidas();
}
