using UnityEngine;
using System.Collections;

public class Nodo {
    public Cliente objeto;
    public Nodo siguiente;
    public Nodo anterior;


    public void RevertirNodo()
    {
        Nodo aux = siguiente;
        siguiente = anterior;
        anterior = aux;
    }
}
