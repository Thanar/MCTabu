using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TSA {

    public Solucion solucionInicial = new Solucion();
    public ProblemaTabu problema;

    public int maxIteraciones;

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
        int i=0;
        generaSolucionInicial();
        while(i<maxIteraciones){
            //trialMoves();
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

        if (resultadoGeni.Count <= 1)
        {
            //break;
        }
        geni = new GENI(problema, problema.clientes[0], resultadoGeni[1], resultadoGeni[2]);
        for (int i = 3; i < resultadoGeni.Count; i++)
        {
            geni.insertarNodo(resultadoGeni[i]);
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
}
