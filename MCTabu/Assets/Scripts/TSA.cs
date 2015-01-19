using UnityEngine;
using System.Collections;

public class TSA : MonoBehaviour {

    public ProblemaTabu problema;
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
        Solucion inicial = generaSolucionInicial();
    }

    void generaSolucionInicial()
    {
        Vehiculo inicial = 1;
        
    }
}
