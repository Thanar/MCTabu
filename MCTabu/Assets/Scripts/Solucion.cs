using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Solucion{

    public List<Ruta> rutas = new List<Ruta>();

    public float coste = 0;
	// Use this for initialization


    public Solucion Clone()
    {
        Solucion dev = new Solucion();

        dev.coste = coste;
        dev.rutas = new List<Ruta>();
        foreach (Ruta r in rutas)
        {
            dev.rutas.Add(r.Clone());
        }
        return dev;
    }

    
}
