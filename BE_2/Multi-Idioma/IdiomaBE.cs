using System.Collections.Generic;

public class IdiomaBE
{
    public int id_idioma { get; set; }
    public string nombre { get; set; } = string.Empty;


    public Dictionary<string, string> diccionario { get; set; } = new Dictionary<string, string>();
}
