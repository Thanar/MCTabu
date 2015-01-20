using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TSA : MonoBehaviour {

    public Solucion solucionInicial;
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
            trialMoves();
            mejorarRuta();
            actualizaListaTabu();
            actualizarContadores();
               if (!criterioParada())
                {
                    if (!middleCycle)
                    {
                        if (!endCycle)
                        {
                         continue;
                        }else{
                            vaciaListaTabu();
                            actualizaDatos();
                        }              
                    }else{
                         actualizaDatos();
                    }          
                }
                else{
                   break;
                }
        }
        
    }

    void generaSolucionInicial()
    {
        
        int aux = 0;
        Cliente auxCliente=null;
        Vehiculo inicial=null;
        Cliente[] clientes = problema.clientes;
        List<Cliente> clientesAptos= new List<Cliente>();
        bool cocheValido = false;
        float distanciaMaxima = 0;
        while (!cocheValido)
        {
            inicial = problema.vehiculos[aux];
            foreach (Cliente i in clientes)
            {
                if (i.Equals(clientes[0]))
                {
                    continue;
                }
                if (i.q < inicial.capacidad)
                {
                    cocheValido = true;
                    clientesAptos.Add(i);
                }
            }
            if (!cocheValido)
            {
                aux++;
            }
        }
        foreach (Cliente i in clientesAptos)
        {
            if (distanciaMaxima<Vector2.Distance(new Vector2(i.x,i.y),new Vector2(problema.clientes[0].x,problema.clientes[0].y))){
                distanciaMaxima = Vector2.Distance(new Vector2(i.x, i.y), new Vector2(problema.clientes[0].x, problema.clientes[0].y));
                auxCliente = i;
            }
        }
        solucionInicial.rutas.Add(new Ruta());
        solucionInicial.rutas[0].recorrido.Add(auxCliente);
        clientesAptos.Remove(auxCliente);
        inicial.cargaActual += auxCliente.q;
        List<Cliente> clientesAux = new List<Cliente>();
        clientesAux.AddRange(clientesAptos);
        foreach (Cliente i in clientesAux)
        {
            if (i.q > inicial.capacidad - inicial.cargaActual)
            {
                clientesAptos.Remove(i);
            }
        }



                
        
       
        
    }
}
