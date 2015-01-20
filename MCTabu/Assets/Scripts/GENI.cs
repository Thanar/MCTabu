using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GENI {

    public List<Cliente> solucionActual = new List<Cliente>();

    ProblemaTabu problema;

    List<Cliente> listaInicial;

    public GENI(ProblemaTabu problema, Cliente a, Cliente b, Cliente c)
    {
        solucionActual.Add(a);
        solucionActual.Add(b);
        solucionActual.Add(c);

        this.problema = problema;
    }

    public void insertarNodo(Cliente v)
    {
        Ruta mejorRuta = null;
        List<Cliente> pVecinos = new List<Cliente>();
        int p = 4;

        pVecinos = solucionActual.OrderBy(c => problema.getDistanciaEntre(c, v) < 10).ToList<Cliente>().GetRange(0,p);

        foreach (Cliente i in pVecinos)
        {
            listaInicial = new List<Cliente>();
            listaInicial.AddRange(solucionActual.GetRange(solucionActual.IndexOf(i), solucionActual.Count - solucionActual.IndexOf(i)));
            listaInicial.AddRange(solucionActual.GetRange(0, solucionActual.IndexOf(i)));

            foreach (Cliente j in pVecinos)
            {
                foreach (Cliente k in solucionActual)
                {
                    if (k == i || k == j)
                    {
                        continue;
                    }
                    if (listaInicial.GetRange(listaInicial.IndexOf(i), listaInicial.IndexOf(j) - listaInicial.IndexOf(i)).Contains(k))
                    {
                        continue;
                    }


                    Ruta auxr = insertarNodoEntreIJConKTipo1(v, i, j, k);
                    //TODO insertar tipo 2
                    if (mejorRuta == null || mejorRuta.costeRuta > auxr.costeRuta)
                    {
                        mejorRuta = auxr;
                    }

                }
            }
        }

        solucionActual.Reverse();

        foreach (Cliente i in pVecinos)
        {
            listaInicial = new List<Cliente>();
            listaInicial.AddRange(solucionActual.GetRange(solucionActual.IndexOf(i), solucionActual.Count - solucionActual.IndexOf(i)));
            listaInicial.AddRange(solucionActual.GetRange(0, solucionActual.IndexOf(i)));

            foreach (Cliente j in pVecinos)
            {
                foreach (Cliente k in solucionActual)
                {
                    if (k == i || k == j)
                    {
                        continue;
                    }
                    if (listaInicial.GetRange(listaInicial.IndexOf(i), listaInicial.IndexOf(j) - listaInicial.IndexOf(i)).Contains(k))
                    {
                        continue;
                    }


                    Ruta auxr = insertarNodoEntreIJConKTipo1(v, i, j, k);
                    //TODO insertar tipo 2
                    if (mejorRuta == null || mejorRuta.costeRuta > auxr.costeRuta)
                    {
                        mejorRuta = auxr;
                    }

                }
            }
        }


        foreach (Cliente i in pVecinos)
        {
            listaInicial = new List<Cliente>();
            listaInicial.AddRange(solucionActual.GetRange(solucionActual.IndexOf(i), solucionActual.Count - solucionActual.IndexOf(i)));
            listaInicial.AddRange(solucionActual.GetRange(0, solucionActual.IndexOf(i)));

            Ruta auxr = insercionEstandar(v, i);
            if (mejorRuta == null || mejorRuta.costeRuta > auxr.costeRuta)
            {
                mejorRuta = auxr;
            }

        }

        solucionActual = mejorRuta.recorrido;

    }

    public Ruta insercionEstandar(Cliente v, Cliente i)
    {

        List<Cliente> listaFinal = new List<Cliente>();
        listaFinal.AddRange(listaInicial);

        listaFinal.Insert(listaFinal.IndexOf(i) + 1, v);

        float coste = 0;

        for (int auxi = 0; auxi < listaFinal.Count; auxi++)
        {
            if (auxi < listaFinal.Count - 1)
            {
                coste += problema.getDistanciaEntre(listaFinal[auxi], listaFinal[auxi + 1]);
            }
            else
            {
                coste += problema.getDistanciaEntre(listaFinal[auxi], listaFinal[0]);
            }
        }

        Ruta auxr = new Ruta() { recorrido = listaFinal, costeRuta = coste };

        listaFinal = new List<Cliente>();
        listaFinal.AddRange(listaInicial);

        listaFinal.Insert(listaFinal.IndexOf(i) + 1, v);

        coste = 0;

        for (int auxi = 0; auxi < listaFinal.Count; auxi++)
        {
            if (auxi < listaFinal.Count - 1)
            {
                coste += problema.getDistanciaEntre(listaFinal[auxi], listaFinal[auxi + 1]);
            }
            else
            {
                coste += problema.getDistanciaEntre(listaFinal[auxi], listaFinal[0]);
            }
        }

        if (coste < auxr.costeRuta)
        {
            auxr = new Ruta() { recorrido = listaFinal, costeRuta = coste };
        }

        return auxr;
    }

    public Ruta insertarNodoEntreIJConKTipo1(Cliente v, Cliente i, Cliente j, Cliente k)
    {

        Cliente k1 = listaInicial[listaInicial.IndexOf(k)+1];

        List<Cliente> i1j = new List<Cliente>();
        List<Cliente> j1k = new List<Cliente>();
        List<Cliente> k1i = new List<Cliente>();

        List<Cliente> listaFinal = new List<Cliente>();



        i1j = listaInicial.GetRange(listaInicial.IndexOf(i), listaInicial.IndexOf(j) - listaInicial.IndexOf(i));
        j1k = listaInicial.GetRange(listaInicial.IndexOf(j), listaInicial.IndexOf(k) - listaInicial.IndexOf(j));
        k1i = listaInicial.GetRange(listaInicial.IndexOf(k), listaInicial.Count - listaInicial.IndexOf(k));



        listaFinal.Add(i);
        listaFinal.Add(v);
        listaFinal.Add(j);

        i1j.Reverse();
        listaFinal.AddRange(i1j);

        listaFinal.Add(k);

        j1k.Reverse();
        listaFinal.AddRange(j1k);

        listaFinal.Add(k1);

        listaFinal.AddRange(k1i);

        float coste = 0;

        for (int auxi = 0; auxi < listaFinal.Count; auxi++)
        {
            if (auxi < listaFinal.Count - 1)
            {
                coste += problema.getDistanciaEntre(listaFinal[auxi], listaFinal[auxi + 1]);
            }
            else
            {
                coste += problema.getDistanciaEntre(listaFinal[auxi], listaFinal[0]);
            }
        }

        return new Ruta() { recorrido = listaFinal, costeRuta = coste };
    }
}
