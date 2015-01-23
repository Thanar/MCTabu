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

        pVecinos = solucionActual.OrderBy(c => problema.getDistanciaEntre(c, v)).ToList<Cliente>().GetRange(0,Mathf.Min(p,solucionActual.Count-1));

        foreach (Cliente i in pVecinos)
        {
            listaInicial = new List<Cliente>();
            listaInicial.AddRange(solucionActual.GetRange(solucionActual.IndexOf(i), solucionActual.Count - solucionActual.IndexOf(i)));
            listaInicial.AddRange(solucionActual.GetRange(0, solucionActual.IndexOf(i)));

            foreach (Cliente j in pVecinos)
            {
                foreach (Cliente k in solucionActual)
                {
                    if (listaInicial.GetRange(listaInicial.IndexOf(i), listaInicial.IndexOf(j) - listaInicial.IndexOf(i)).Contains(k))
                    {
                        continue;
                    }
                    if (k == j)
                    {
                        continue;
                    }

                    Ruta auxr = null;
                    if (k != i)
                    {
                        auxr = insertarNodoEntreIJConKTipo1(v, i, j, k);
                    }
                    if (auxr != null && (mejorRuta == null || mejorRuta.costeRuta > auxr.costeRuta))
                    {
                        mejorRuta = auxr;
                    }

                    if (k != listaInicial[listaInicial.IndexOf(j) + 1])
                    {
                        foreach (Cliente l in solucionActual)
                        {
                            if (l == i || l == listaInicial[listaInicial.IndexOf(i) + 1])
                            {
                                continue;
                            }
                            if (!listaInicial.GetRange(listaInicial.IndexOf(i), listaInicial.IndexOf(j) - listaInicial.IndexOf(i)).Contains(l))
                            {
                                continue;
                            }

                            auxr = insertarNodoEntreIJConKyLTipo2(v, i, j, k, l);
                        }
                    }
                    if (auxr != null && (mejorRuta == null || mejorRuta.costeRuta > auxr.costeRuta))
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
                    if (listaInicial.GetRange(listaInicial.IndexOf(i), listaInicial.IndexOf(j) - listaInicial.IndexOf(i)).Contains(k))
                    {
                        continue;
                    }
                    if (k == j)
                    {
                        continue;
                    }

                    Ruta auxr = null;
                    if (k != i)
                    {
                        auxr = insertarNodoEntreIJConKTipo1(v, i, j, k);
                    }
                    if (auxr!=null && (mejorRuta == null || mejorRuta.costeRuta > auxr.costeRuta))
                    {
                        mejorRuta = auxr;
                    }

                    if (k != listaInicial[listaInicial.IndexOf(j) + 1])
                    {
                        foreach (Cliente l in solucionActual)
                        {
                            if (l == i || l == listaInicial[listaInicial.IndexOf(i) + 1])
                            {
                                continue;
                            }
                            if (!listaInicial.GetRange(listaInicial.IndexOf(i), listaInicial.IndexOf(j) - listaInicial.IndexOf(i)).Contains(l))
                            {
                                continue;
                            }

                            auxr = insertarNodoEntreIJConKyLTipo2(v, i, j, k, l);
                        }
                    }
                    if (auxr != null && (mejorRuta == null || mejorRuta.costeRuta > auxr.costeRuta))
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
        Debug.Log(mejorRuta.origen);
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

        Ruta auxr = new Ruta() { recorrido = listaFinal, costeRuta = coste, origen = "estandar" };
        /*
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
        */
        return auxr;
    }

    public Ruta insertarNodoEntreIJConKTipo1(Cliente v, Cliente i, Cliente j, Cliente k)
    {
        
        Cliente k1 = null;
        if (listaInicial.IndexOf(k) != listaInicial.Count - 1)
        {
            k1 = listaInicial[listaInicial.IndexOf(k) + 1];
        }
        else
        {
            k1 = i;
        }

        List<Cliente> i1j = new List<Cliente>();
        List<Cliente> j1k = new List<Cliente>();
        List<Cliente> k1i = new List<Cliente>();

        List<Cliente> listaFinal = new List<Cliente>();



        i1j = listaInicial.GetRange(listaInicial.IndexOf(i)+1, listaInicial.IndexOf(j) - listaInicial.IndexOf(i));
        j1k = listaInicial.GetRange(listaInicial.IndexOf(j)+1, listaInicial.IndexOf(k) - listaInicial.IndexOf(j));
        if (listaInicial.IndexOf(k) != listaInicial.Count-1)
        {
            k1i = listaInicial.GetRange(listaInicial.IndexOf(k) + 1, listaInicial.Count - listaInicial.IndexOf(k)-1);
        }



        listaFinal.Add(i);
        listaFinal.Add(v);
        //listaFinal.Add(j);

        i1j.Reverse();
        listaFinal.AddRange(i1j);

        //listaFinal.Add(k);

        j1k.Reverse();
        listaFinal.AddRange(j1k);

        //listaFinal.Add(k1);

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

        return new Ruta() { recorrido = listaFinal, costeRuta = coste, origen = "Tipo1" };
    }



    public Ruta insertarNodoEntreIJConKyLTipo2(Cliente v, Cliente i, Cliente j, Cliente k, Cliente l)
    {
        Cliente k1 = listaInicial[listaInicial.IndexOf(k) - 1];
        Cliente l1 = listaInicial[listaInicial.IndexOf(k) - 1];

        List<Cliente> i1l1 = new List<Cliente>();
        List<Cliente> lj = new List<Cliente>();
        List<Cliente> j1k1 = new List<Cliente>();
        List<Cliente> ki = new List<Cliente>();

        List<Cliente> listaFinal = new List<Cliente>();



        i1l1 = listaInicial.GetRange(listaInicial.IndexOf(i) + 1, listaInicial.IndexOf(l) - 1 - listaInicial.IndexOf(i) );
        lj = listaInicial.GetRange(listaInicial.IndexOf(l), listaInicial.IndexOf(j) - listaInicial.IndexOf(l)+1);
        j1k1 = listaInicial.GetRange(listaInicial.IndexOf(j) + 1, listaInicial.IndexOf(k) - 1 - listaInicial.IndexOf(j) );
        ki = listaInicial.GetRange(listaInicial.IndexOf(k), listaInicial.Count - listaInicial.IndexOf(k));


        listaFinal.Add(i);
        listaFinal.Add(v);
        //listaFinal.Add(j);

        lj.Reverse();
        listaFinal.AddRange(lj);

        listaFinal.AddRange(j1k1);

        i1l1.Reverse();
        listaFinal.AddRange(i1l1);

        listaFinal.AddRange(ki);


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

        return new Ruta() { recorrido = listaFinal, costeRuta = coste , origen="Tipo2"};


    }
}
