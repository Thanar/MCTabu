using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TSA {

    public Solucion solucionInicial = new Solucion();

    public Solucion MejorSolucion;

    public Solucion bestFeasibleSolution = new Solucion();
    public Solucion bestInfeasibleSolution = new Solucion();

    public Dictionary<Cliente, int> tabuList = new Dictionary<Cliente, int>();

    public int FrequencyDouble = 10;
    public int FrequencySwap = 5;
    public float Penalty = 1;
    public int Fase = 1;
    public int nVecinos = 3;
    public int maxNVecinos;
    public int TabuMaxPenalty;

    public ProblemaTabu problema;

    public int maxIteraciones;
    public int iterationCounter = 0;
    public int cycleCounter = 0;
    public int NumberRestartsForBestFeasible = 0;
    public int iterationsSinceBestFound = 0;
    public int iterationsSinceBestFeasibleFound = 0;
    public int ConsecutiveIterationsFeasible = 0;
    public int ConsecutiveIterationsInfeasible = 0;

    public int maxSinceBestFound;
    public int maxSinceBestFeasibleFound;

    public List<Arista> listaTabu= new List<Arista>();
    
    public float costeSolucion;
	// Use this for initialization
	void Start () {
        problema = new ProblemaTabu(3);
        solucionarProblema();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void solucionarProblema()
    {
        generaSolucionInicial();
        MejorSolucion = solucionInicial.Clone();
        bestFeasibleSolution = solucionInicial.Clone();
        TabuMaxPenalty = problema.clientes.Length / 2;
        maxIteraciones = (int)(3000 * Mathf.Sqrt(problema.clientes.Length));
        maxSinceBestFound = 15 * problema.clientes.Length;
        maxSinceBestFeasibleFound = 30 * problema.clientes.Length;

        maxNVecinos = Mathf.Min(problema.clientes.Length - 1, 2 * solucionInicial.rutas.Max(r => r.recorrido.Count)); //solucionInicial.rutas.OrderByDescending(r => r.recorrido.Count).First().recorrido.Count);
        
        while(iterationCounter<maxIteraciones){
            trialMoves();
            //mejorarRuta();
            //actualizaListaTabu();
            //actualizarContadores();
            //   if (!criterioParada())
            //    {
            //        if (!middleCycle)
            //        {
            //            if (!endCycle)
            //            {
            //             continue;
            //            }else{
            //                vaciaListaTabu();
            //                actualizaDatos();
            //            }              
            //        }else{
            //             actualizaDatos();
            //        }          
            //    }
                //else{
                //   break;
                //}
        }
        
    }

    private void trialMoves()
    {
        Solucion MejorSolucionEncontrada = new Solucion();
        Solucion auxSolucion;
        MejorSolucion.coste = float.MaxValue;
        foreach (Cliente c in problema.clientes)
        {
            if (c == problema.clientes[0])
            {
                continue;
            }
            auxSolucion = solucionInicial.Clone();
            List<Ruta> RutasConVecinos = auxSolucion.rutas.Where(r => r.recorrido.Intersect(Vecinos(c)).Count() > 0 && !r.recorrido.Contains(c)).ToList();


            Ruta mejor = null;
            float diferenciaMejorRuta=float.MaxValue;
            foreach (Ruta r in RutasConVecinos)
            {
                Ruta aux;
                for (int i = 1; i <= r.recorrido.Count; i++)
                {
                    aux = r.Clone();
                    aux.recorrido.Insert(i, c);
                    if(CalcularCoste(aux)- CalcularCoste(r) < diferenciaMejorRuta)
                    {
                        mejor = r;
                        diferenciaMejorRuta = CalcularCoste(aux) - CalcularCoste(r);
                    }
                }
            }








            Ruta miRutaOrigen = auxSolucion.rutas.First(r => r.recorrido.Contains(c));

            miRutaOrigen.recorrido.Remove(c);


            GENI g = new GENI(problema, null, null, null);
            g.solucionActual = mejor.recorrido;
            g.insertarNodo(c);

            List<Cliente> resultadoGeni = g.solucionActual.GetRange(g.solucionActual.IndexOf(problema.clientes[0]), g.solucionActual.Count - g.solucionActual.IndexOf(problema.clientes[0]));
            resultadoGeni.AddRange(g.solucionActual.GetRange(0, g.solucionActual.IndexOf(problema.clientes[0])));
            mejor.recorrido = resultadoGeni;


        }
    }



    public void generaSolucionInicial()
    {
        GENI geni = new GENI(problema, problema.clientes[0], problema.clientes[1], problema.clientes[2]);
        for (int i = 3; i < problema.clientes.Length; i++)
        {
            geni.insertarNodo(problema.clientes[i]);
        }
        List<Cliente> resultadoGeni = geni.solucionActual.GetRange(geni.solucionActual.IndexOf(problema.clientes[0]), geni.solucionActual.Count - geni.solucionActual.IndexOf(problema.clientes[0]));
        resultadoGeni.AddRange(geni.solucionActual.GetRange(0, geni.solucionActual.IndexOf(problema.clientes[0])));


        int rutaActual = 0;
        solucionInicial.rutas.Add(new Ruta());
        solucionInicial.rutas[rutaActual].recorrido.Add(problema.clientes[0]);

        Cliente siguiente = resultadoGeni[1];
        Vehiculo auxv = problema.vehiculos.Where(v => v.capacidad >= siguiente.q).OrderBy(v => v.capacidad).First<Vehiculo>();
        auxv.cargaActual = siguiente.q;
        solucionInicial.rutas[rutaActual].tipoUtilizado = auxv;
        for (int i = 2; i < resultadoGeni.Count; i++)
        {
            if (auxv.capacidadActual() <= resultadoGeni[i].q)
            {
                solucionInicial.rutas[rutaActual].recorrido.Add(resultadoGeni[i]);
                auxv.cargaActual += siguiente.q;
            }
        }
        resultadoGeni.RemoveAll(c => solucionInicial.rutas[rutaActual].recorrido.Contains(c) && c != problema.clientes[0]);

        while (resultadoGeni.Count > 1)
        {
            //break;

#region Bloque a eliminar si no hay que hacer varios GENI
            geni = new GENI(problema, problema.clientes[0], resultadoGeni[1], resultadoGeni[2]);
            for (int i = 3; i < resultadoGeni.Count; i++)
            {
                geni.insertarNodo(resultadoGeni[i]);
            }
            resultadoGeni.Clear();
            resultadoGeni = geni.solucionActual.GetRange(geni.solucionActual.IndexOf(problema.clientes[0]), geni.solucionActual.Count - geni.solucionActual.IndexOf(problema.clientes[0]));
            resultadoGeni.AddRange(geni.solucionActual.GetRange(0, geni.solucionActual.IndexOf(problema.clientes[0])));
#endregion

            rutaActual++;
            solucionInicial.rutas.Add(new Ruta());
            solucionInicial.rutas[rutaActual].recorrido.Add(problema.clientes[0]);

            siguiente = resultadoGeni[1];
            auxv = problema.vehiculos.Where(v => v.capacidad >= siguiente.q).OrderBy(v => v.capacidad).First<Vehiculo>();
            auxv.cargaActual = siguiente.q;
            solucionInicial.rutas[rutaActual].tipoUtilizado = auxv;
            for (int i = 2; i < resultadoGeni.Count; i++)
            {
                if (auxv.capacidadActual() <= resultadoGeni[i].q)
                {
                    solucionInicial.rutas[rutaActual].recorrido.Add(resultadoGeni[i]);
                    auxv.cargaActual += siguiente.q;
                }
            }
            resultadoGeni.RemoveAll(c => solucionInicial.rutas[rutaActual].recorrido.Contains(c) && c != problema.clientes[0]);
        }

    }





    //void generaSolucionInicial()
    //{
        
    //    int aux = 0;
    //    Cliente auxCliente=null;
    //    Vehiculo inicial=null;
    //    Cliente[] clientes = problema.clientes;
    //    List<Cliente> clientesAptos= new List<Cliente>();
    //    bool cocheValido = false;
    //    float distanciaMaxima = 0;
    //    while (!cocheValido)
    //    {
    //        inicial = problema.vehiculos[aux];
    //        foreach (Cliente i in clientes)
    //        {
    //            if (i.Equals(clientes[0]))
    //            {
    //                continue;
    //            }
    //            if (i.q < inicial.capacidad)
    //            {
    //                cocheValido = true;
    //                clientesAptos.Add(i);
    //            }
    //        }
    //        if (!cocheValido)
    //        {
    //            aux++;
    //        }
    //    }
    //    foreach (Cliente i in clientesAptos)
    //    {
    //        if (distanciaMaxima<Vector2.Distance(new Vector2(i.x,i.y),new Vector2(problema.clientes[0].x,problema.clientes[0].y))){
    //            distanciaMaxima = Vector2.Distance(new Vector2(i.x, i.y), new Vector2(problema.clientes[0].x, problema.clientes[0].y));
    //            auxCliente = i;
    //        }
    //    }
    //    solucionInicial.rutas.Add(new Ruta());
    //    solucionInicial.rutas[0].recorrido.Add(auxCliente);
    //    clientesAptos.Remove(auxCliente);
    //    inicial.cargaActual += auxCliente.q;
    //    List<Cliente> clientesAux = new List<Cliente>();
    //    clientesAux.AddRange(clientesAptos);
    //    foreach (Cliente i in clientesAux)
    //    {
    //        if (i.q > inicial.capacidad - inicial.cargaActual)
    //        {
    //            clientesAptos.Remove(i);
    //        }
    //    }



    //}





    public void CalcularCoste(Solucion s)
    {
        s.coste = 0;
        foreach (Ruta r in s.rutas)
        {
            r.calculaCarga();
            s.coste += r.tipoUtilizado.costeFijo;
            s.coste += r.tipoUtilizado.costeVariable * r.costeRuta;
            s.coste += Penalty * Mathf.Max(0, r.carga - r.tipoUtilizado.capacidad);
        }
        
    }

    public float CalcularCoste(Ruta r)
    {
        float coste = 0;
        r.calculaCarga();
        coste += r.tipoUtilizado.costeFijo;
        coste += r.tipoUtilizado.costeVariable * r.costeRuta;
        coste += Penalty * Mathf.Max(0, r.carga - r.tipoUtilizado.capacidad);

        return coste;
    }


    public List<Cliente> Vecinos(Cliente cliente)
    {
        return problema.clientes.Where(c => c != cliente).OrderBy(c => problema.getDistanciaEntre(cliente, c)).ToList().GetRange(0, nVecinos);
    }
}
