using UnityEngine;
using System.Collections;

public class ProblemaTabu {
    public Arista[,] problema;
    public Cliente[] clientes;

    public ProblemaTabu(Cliente[] clientes, Arista[,] problema)
    {
        this.problema = problema;
        this.clientes = clientes;
    }
}
