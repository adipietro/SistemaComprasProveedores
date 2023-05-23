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


public class GrupoPatenteBE : PatenteAbsBE
{
    private HashSet<BE.PatenteAbsBE> setPatentes = new HashSet<BE.PatenteAbsBE>();

    public HashSet<BE.PatenteAbsBE> Patentes
    {
        get
        {
            return setPatentes;
        }
        set
        {
            setPatentes = value;
        }
    }


    public override bool Permite(string formulario)
    {
        foreach (var patente in setPatentes)
        {
            if (patente.Permite(formulario))
                return true;
        }
        return false;
    }

    public override HashSet<PatenteBE> ListarPatentesHojasPermitidas()
    {
        HashSet<PatenteBE> ret = new HashSet<PatenteBE>();
        foreach (var patente in setPatentes)
            ret.UnionWith(patente.ListarPatentesHojasPermitidas());
        return ret;
    }
}
