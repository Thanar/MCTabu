using UnityEngine;
using System.Collections;

public class GENITEST : MonoBehaviour {


    GENI geni;

    ProblemaTabu problema;

    public GameObject NodoPrefab;

    public GameObject AristaPrefab;

    int siguiente = 3;

	// Use this for initialization
	void Start () {

        problema = new ProblemaTabu(3);

        foreach (Cliente c in problema.clientes)
        {
            GameObject.Instantiate(NodoPrefab, new Vector3(c.x, 0, c.y), Quaternion.identity);
        }

        geni = new GENI(problema, problema.clientes[0], problema.clientes[1], problema.clientes[2]);
        //geni.insertarNodo(problema.clientes[3]);
        //for (int i = 4; i < problema.clientes.Length; i++)
        //{
        //    geni.insertarNodo(problema.clientes[i]);
        //}

            for (int i = 0; i < geni.solucionActual.Count; i++)
            {
                GameObject a = GameObject.Instantiate(AristaPrefab) as GameObject;
                LineRenderer lr = a.GetComponent<LineRenderer>();

                lr.SetPosition(0, new Vector3(geni.solucionActual[i].x, 0, geni.solucionActual[i].y));
                if (i != 0)
                {
                    lr.SetPosition(1, new Vector3(geni.solucionActual[i - 1].x, 0, geni.solucionActual[i - 1].y));
                }
                else
                {
                    lr.SetPosition(1, new Vector3(geni.solucionActual[geni.solucionActual.Count - 1].x, 0, geni.solucionActual[geni.solucionActual.Count - 1].y));
                }
            }
	}


    public void insertarNodo()
    {
        geni.insertarNodo(problema.clientes[siguiente]);
        siguiente++;
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("arista"))
        {
            GameObject.Destroy(go);
        }
        for (int i = 0; i < geni.solucionActual.Count; i++)
        {
            GameObject a = GameObject.Instantiate(AristaPrefab) as GameObject;
            LineRenderer lr = a.GetComponent<LineRenderer>();

            lr.SetPosition(0, new Vector3(geni.solucionActual[i].x, 0, geni.solucionActual[i].y));
            if (i != 0)
            {
                lr.SetPosition(1, new Vector3(geni.solucionActual[i - 1].x, 0, geni.solucionActual[i - 1].y));
            }
            else
            {
                lr.SetPosition(1, new Vector3(geni.solucionActual[geni.solucionActual.Count - 1].x, 0, geni.solucionActual[geni.solucionActual.Count - 1].y));
            }
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
