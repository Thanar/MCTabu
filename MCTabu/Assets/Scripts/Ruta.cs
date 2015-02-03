using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Ruta {

    public List<Cliente> recorrido = new List<Cliente>();
    public Vehiculo tipoUtilizado;
    public float costeRuta;
    public string origen = "";
    public float carga=0;

    public float calculaCarga()
    {
        carga = 0;
        foreach (Cliente c in recorrido)
        {
            carga += c.q;
        }
        return carga;
    }


    public Ruta Clone()
    {
        Ruta dev = new Ruta();

        dev.carga = carga;
        dev.origen = origen;
        dev.costeRuta = costeRuta;
        dev.tipoUtilizado = tipoUtilizado;
        dev.recorrido = new List<Cliente>();
        foreach (Cliente c in recorrido)
        {
            dev.recorrido.Add(c);
        }
        return dev;
    }
	
}
