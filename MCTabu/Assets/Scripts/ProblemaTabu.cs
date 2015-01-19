using UnityEngine;
using System.Collections;

public class ProblemaTabu {
    public Cliente[] clientes;

    public ProblemaTabu(int i)
    {
        clientes = generaDatosProblema(i);
    }

    public ProblemaTabu(Cliente[] clientes)
    {
        this.clientes = clientes;
    }



    private Cliente[] generaDatosProblema(int i)
    { 
        Cliente[] clientes = null;
        switch (i)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                clientes = generaDatosProblema3();
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
        }
        return clientes;
    }

    private Cliente[] generaDatosProblema3()
    {
        Cliente[] clientes = new Cliente[50];

        clientes[0] = new Cliente(30, 40, 0);
        clientes[1] = new Cliente(37, 52, 7);
        clientes[2] = new Cliente(49,49 ,30 );
        clientes[3] = new Cliente(52,64 ,16 );
        clientes[4] = new Cliente(20,26 ,9 );
        clientes[5] = new Cliente(40,30 ,21 );
        clientes[6] = new Cliente(21, 47,15 );
        clientes[7] = new Cliente(17, 63,19 );
        clientes[8] = new Cliente(31, 62,23 );
        clientes[9] = new Cliente(52, 33,11 );
        clientes[10] = new Cliente(51, 21,5 );
        clientes[11] = new Cliente(42, 41,19 );
        clientes[12] = new Cliente(31, 32,29 );
        clientes[13] = new Cliente(5, 25,23 );
        clientes[14] = new Cliente(12,42 ,21 );
        clientes[15] = new Cliente(36,16 ,10 );
        clientes[16] = new Cliente(52,41 ,15 );
        clientes[17] = new Cliente(27,23 ,3 );
        clientes[18] = new Cliente(17,33 ,41 );
        clientes[19] = new Cliente(13,13 ,9 );
        clientes[20] = new Cliente(57,58 ,28 );
        clientes[21] = new Cliente(62,42 ,8 );
        clientes[22] = new Cliente(42,57 ,8 );
        clientes[23] = new Cliente(16,57 , 16);
        clientes[24] = new Cliente(8,52 ,10 );
        clientes[25] = new Cliente(7,38 ,28 );
        clientes[26] = new Cliente(27,68 ,7 );
        clientes[27] = new Cliente(30,48 ,15 );
        clientes[28] = new Cliente(43,67 ,14 );
        clientes[29] = new Cliente(58,48,6 );
        clientes[30] = new Cliente(58,27 ,19 );
        clientes[31] = new Cliente(37,69 ,11 );
        clientes[32] = new Cliente(38,46,12);
        clientes[33] = new Cliente(46,10,23);
        clientes[34] = new Cliente(61,33,26);
        clientes[35] = new Cliente(62,63,17);
        clientes[36] = new Cliente(63,69,6);
        clientes[37] = new Cliente(32,22,9);
        clientes[38] = new Cliente(45,35,15);
        clientes[39] = new Cliente(59,15,14);
        clientes[40] = new Cliente(5,6,7);
        clientes[41] = new Cliente(10,17,27);
        clientes[42] = new Cliente(21,10,13);
        clientes[43] = new Cliente(5,64,11);
        clientes[44] = new Cliente(30,15,16);
        clientes[45] = new Cliente(39,10,10);
        clientes[46] = new Cliente(32,39,5);
        clientes[47] = new Cliente(25,32,25);
        clientes[48] = new Cliente(25,55,17);
        clientes[49] = new Cliente(48,28,18);
        clientes[50] = new Cliente(56,37,10);

        return clientes;
    }


}
