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

public class PatenteBE : PatenteAbsBE
{

    // Aca agregamos las operaciones que afectan a todos las Patentes

    public string formulario { get; set; }
    public string menu { get; set; }

    public override bool Permite(string formulario)
    {
        return this.formulario == formulario;
    }

    public override HashSet<PatenteBE> ListarPatentesHojasPermitidas()
    {
        HashSet<PatenteBE> ret = new HashSet<PatenteBE>();
        ret.Add(this);
        return ret;
    }
}
