using UnityEngine;
using System.Collections;

public class ProblemaTabu {
    public Cliente[] clientes;
    public Vehiculo[] vehiculos;

    public ProblemaTabu(int i)
    {
        generaDatosProblema(i);
    }

    public ProblemaTabu(Cliente[] clientes)
    {
        this.clientes = clientes;
    }



    private void generaDatosProblema(int i)
    { 
        switch (i)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                generaDatosProblema3();
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
    }

    private void generaDatosProblema3()
    {
        Cliente [] clients = genera50Clientes();
        clientes = new Cliente[20];
        for (int i = 0; i < 20; i++)
        {
            clientes[i] = clients[i];
        }

        vehiculos = new Vehiculo[5];

        vehiculos[0] = new Vehiculo() { capacidad=20,costeFijo=20};
        vehiculos[1] = new Vehiculo() { capacidad = 30, costeFijo = 35 };
        vehiculos[2] = new Vehiculo() { capacidad = 40, costeFijo = 50 };
        vehiculos[3] = new Vehiculo() { capacidad = 70, costeFijo = 120 };
        vehiculos[4] = new Vehiculo() { capacidad = 120, costeFijo = 225 };

    }

    public void generaDatosProblema4()
    {
        Cliente[] clients = genera50Clientes();
        clientes = new Cliente[20];
        for (int i = 0; i < 20; i++)
        {
            clientes[i] = clients[i];
        }

        vehiculos = new Vehiculo[5];

        vehiculos[0] = new Vehiculo() { capacidad = 60, costeFijo = 1000 };
        vehiculos[1] = new Vehiculo() { capacidad = 80, costeFijo = 1500 };
        vehiculos[2] = new Vehiculo() { capacidad = 150, costeFijo = 3000 };
    }


    public Cliente[] genera50Clientes()
    {
        Cliente[] clients = new Cliente[50];

        clients[0] = new Cliente(30, 40, 0);

        clients[1] = new Cliente(37, 52, 7);
        clients[2] = new Cliente(49, 49, 30);
        clients[3] = new Cliente(52, 64, 16);
        clients[4] = new Cliente(20, 26, 9);
        clients[5] = new Cliente(40, 30, 21);
        clients[6] = new Cliente(21, 47, 15);
        clients[7] = new Cliente(17, 63, 19);
        clients[8] = new Cliente(31, 62, 23);
        clients[9] = new Cliente(52, 33, 11);
        clients[10] = new Cliente(51, 21, 5);
        clients[11] = new Cliente(42, 41, 19);
        clients[12] = new Cliente(31, 32, 29);
        clients[13] = new Cliente(5, 25, 23);
        clients[14] = new Cliente(12, 42, 21);
        clients[15] = new Cliente(36, 16, 10);
        clients[16] = new Cliente(52, 41, 15);
        clients[17] = new Cliente(27, 23, 3);
        clients[18] = new Cliente(17, 33, 41);
        clients[19] = new Cliente(13, 13, 9);
        clients[20] = new Cliente(57, 58, 28);
        clients[21] = new Cliente(62, 42, 8);
        clients[22] = new Cliente(42, 57, 8);
        clients[23] = new Cliente(16, 57, 16);
        clients[24] = new Cliente(8, 52, 10);
        clients[25] = new Cliente(7, 38, 28);
        clients[26] = new Cliente(27, 68, 7);
        clients[27] = new Cliente(30, 48, 15);
        clients[28] = new Cliente(43, 67, 14);
        clients[29] = new Cliente(58, 48, 6);
        clients[30] = new Cliente(58, 27, 19);
        clients[31] = new Cliente(37, 69, 11);
        clients[32] = new Cliente(38, 46, 12);
        clients[33] = new Cliente(46, 10, 23);
        clients[34] = new Cliente(61, 33, 26);
        clients[35] = new Cliente(62, 63, 17);
        clients[36] = new Cliente(63, 69, 6);
        clients[37] = new Cliente(32, 22, 9);
        clients[38] = new Cliente(45, 35, 15);
        clients[39] = new Cliente(59, 15, 14);
        clients[40] = new Cliente(5, 6, 7);
        clients[41] = new Cliente(10, 17, 27);
        clients[42] = new Cliente(21, 10, 13);
        clients[43] = new Cliente(5, 64, 11);
        clients[44] = new Cliente(30, 15, 16);
        clients[45] = new Cliente(39, 10, 10);
        clients[46] = new Cliente(32, 39, 5);
        clients[47] = new Cliente(25, 32, 25);
        clients[48] = new Cliente(25, 55, 17);
        clients[49] = new Cliente(48, 28, 18);
        clients[50] = new Cliente(56, 37, 10);

        return clients;
    }

    public Cliente[] genera75Clientes()
    {
        Cliente[] clients = new Cliente[75];

        clients[0] = new Cliente(40,40,0);

        clients[1] = new Cliente(22, 22, 18);
        clients[26] = new Cliente(41, 46, 18);
        clients[51] = new Cliente(29, 39, 12);
        clients[2] = new Cliente(36, 26, 26);
        clients[27] = new Cliente(55, 34, 17);
        clients[52] = new Cliente(54, 38, 19);
        clients[3] = new Cliente(21, 45, 11);
        clients[28] = new Cliente(35, 16, 29);
        clients[53] = new Cliente(55, 57, 22);
        clients[4] = new Cliente(45, 35, 30);
        clients[29] = new Cliente(52, 26, 13);
        clients[54] = new Cliente(67, 41, 16);
        clients[5] = new Cliente(55, 20, 21);
        clients[30] = new Cliente(43, 26, 22);
        clients[55] = new Cliente(10, 70, 7);
        clients[6] = new Cliente(33, 34, 19);
        clients[31] = new Cliente(31, 76, 25);
        clients[56] = new Cliente(6, 25, 26);
        clients[7] = new Cliente(50, 50, 15);
        clients[32] = new Cliente(22, 53, 28);
        clients[57] = new Cliente(65, 27, 14);
        clients[8] = new Cliente(55, 45, 16);
        clients[33] = new Cliente(26, 29, 27);
        clients[58] = new Cliente(40, 60, 21);
        clients[9] = new Cliente(26, 59, 29);
        clients[34] = new Cliente(50, 40, 19);
        clients[59] = new Cliente(70, 64, 24);
        clients[10] = new Cliente(40, 66, 26);
        clients[35] = new Cliente(55, 50, 10);
        clients[60] = new Cliente(64, 4, 13);
        clients[11] = new Cliente(55, 65, 37);
        clients[36] = new Cliente(54, 10, 12);
        clients[61] = new Cliente(36, 6, 15);
        clients[12] = new Cliente(35, 51, 16);
        clients[37] = new Cliente(60, 15, 14);
        clients[62] = new Cliente(30, 20, 18);
        clients[13] = new Cliente(62, 35, 12);
        clients[38] = new Cliente(47, 66, 24);
        clients[63] = new Cliente(20, 30, 11);
        clients[14] = new Cliente(62, 57, 31);
        clients[39] = new Cliente(30, 60, 16);
        clients[64] = new Cliente(15, 5, 28);
        clients[15] = new Cliente(62, 24, 8);
        clients[40] = new Cliente(30, 50, 33);
        clients[65] = new Cliente(50, 70, 9);
        clients[16] = new Cliente(21, 36, 19);
        clients[41] = new Cliente(12, 17, 15);
        clients[66] = new Cliente(57, 72, 37);
        clients[17] = new Cliente(33, 44, 20);
        clients[42] = new Cliente(15, 14, 11);
        clients[67] = new Cliente(45, 42, 30);
        clients[18] = new Cliente(9, 56, 13);
        clients[43] = new Cliente(16, 19, 18);
        clients[68] = new Cliente(38, 33, 10);
        clients[19] = new Cliente(62, 48, 15);
        clients[44] = new Cliente(21, 48, 17);
        clients[69] = new Cliente(50, 4, 8);
        clients[20] = new Cliente(66, 14, 22);
        clients[45] = new Cliente(50, 30, 21);
        clients[70] = new Cliente(66, 8, 11);
        clients[21] = new Cliente(44, 13, 28);
        clients[46] = new Cliente(51, 42, 27);
        clients[71] = new Cliente(59, 5, 3);
        clients[22] = new Cliente(26, 13, 12);
        clients[47] = new Cliente(50, 15, 19);
        clients[72] = new Cliente(35, 60, 1);
        clients[23] = new Cliente(11, 28, 6);
        clients[48] = new Cliente(48, 21, 20);
        clients[73] = new Cliente(27, 24, 6);
        clients[24] = new Cliente(7, 43, 27);
        clients[49] = new Cliente(12, 38, 5);
        clients[74] = new Cliente(40, 20, 10);
        clients[25] = new Cliente(17, 64, 14);
        clients[50] = new Cliente(15, 56, 22);
        clients[75] = new Cliente(40, 37, 20);

        return clients;
    }

    public Cliente[] genera100Clientes()
    {

        Cliente[] clients = new Cliente[100];

        clients[0] = new Cliente(35,35,0);

        clients[1] = new Cliente(41, 49, 10);
        clients[35] = new Cliente(63, 65, 8);
        clients[68] = new Cliente(56, 39, 36);
        clients[2] = new Cliente(35, 17, 7);
        clients[36] = new Cliente(2, 60, 5);
        clients[69] = new Cliente(37, 47, 6);
        clients[3] = new Cliente(55, 45, 13);
        clients[37] = new Cliente(20, 20, 8);
        clients[70] = new Cliente(37, 56, 5);
        clients[4] = new Cliente(55, 20, 19);
        clients[38] = new Cliente(5, 5, 16);
        clients[71] = new Cliente(57, 68, 15);
        clients[5] = new Cliente(15, 30, 26);
        clients[39] = new Cliente(60, 12, 31);
        clients[72] = new Cliente(47, 16, 25);
        clients[6] = new Cliente(25, 30, 3);
        clients[40] = new Cliente(40, 25, 9);
        clients[73] = new Cliente(44, 17, 9);
        clients[7] = new Cliente(20, 50, 5);
        clients[41] = new Cliente(42, 7, 5);
        clients[74] = new Cliente(46, 13, 8);
        clients[8] = new Cliente(10, 43, 9);
        clients[42] = new Cliente(24, 12, 5);
        clients[75] = new Cliente(49, 11, 18);
        clients[9] = new Cliente(55, 60, 16);
        clients[43] = new Cliente(23, 3, 7);
        clients[76] = new Cliente(49, 42, 13);
        clients[10] = new Cliente(30, 60, 16);
        clients[44] = new Cliente(11, 14, 18);
        clients[77] = new Cliente(53, 43, 14);
        clients[11] = new Cliente(20, 65, 12);
        clients[45] = new Cliente(6, 38, 16);
        clients[78] = new Cliente(61, 52, 3);
        clients[12] = new Cliente(50, 35, 19);
        clients[46] = new Cliente(2, 48, 1);
        clients[79] = new Cliente(57, 48, 23);
        clients[13] = new Cliente(30, 25, 23);
        clients[47] = new Cliente(8, 56, 27);
        clients[80] = new Cliente(56, 37, 6);
        clients[14] = new Cliente(15, 10, 20);
        clients[48] = new Cliente(13, 52, 36);
        clients[81] = new Cliente(55, 54, 26);
        clients[15] = new Cliente(30, 5, 8);
        clients[49] = new Cliente(6, 68, 30);
        clients[82] = new Cliente(15, 47, 16);
        clients[16] = new Cliente(10, 20, 19);
        clients[50] = new Cliente(47, 47, 13);
        clients[83] = new Cliente(14, 37, 11);
        clients[17] = new Cliente(5, 30, 2);
        clients[51] = new Cliente(49, 58, 10);
        clients[84] = new Cliente(11, 31, 7);
        clients[18] = new Cliente(20, 40, 12);
        clients[52] = new Cliente(27, 43, 9);
        clients[85] = new Cliente(16, 22, 41);
        clients[19] = new Cliente(15, 60, 17);
        clients[53] = new Cliente(37, 31, 14);
        clients[86] = new Cliente(4, 18, 35);
        clients[20] = new Cliente(45, 65, 9);
        clients[54] = new Cliente(57, 29, 18);
        clients[87] = new Cliente(28, 18, 26);
        clients[21] = new Cliente(45, 20, 11);
        clients[55] = new Cliente(63, 23, 2);
        clients[88] = new Cliente(26, 52, 9);
        clients[22] = new Cliente(45, 10, 18);
        clients[56] = new Cliente(53, 12, 6);
        clients[89] = new Cliente(26, 35, 15);
        clients[23] = new Cliente(55, 5, 29);
        clients[57] = new Cliente(32, 12, 7);
        clients[90] = new Cliente(31, 67, 3);
        clients[24] = new Cliente(65, 35, 3);
        clients[58] = new Cliente(36, 26, 18);
        clients[91] = new Cliente(15, 19, 1);
        clients[25] = new Cliente(65, 20, 6);
        clients[59] = new Cliente(21, 24, 28);
        clients[92] = new Cliente(22, 22, 2);
        clients[26] = new Cliente(45, 30, 17);
        clients[60] = new Cliente(17, 34, 3);
        clients[93] = new Cliente(18, 24, 22);
        clients[27] = new Cliente(35, 40, 16);
        clients[61] = new Cliente(12, 24, 13);
        clients[94] = new Cliente(26, 27, 27);
        clients[28] = new Cliente(41, 37, 16);
        clients[62] = new Cliente(24, 58, 19);
        clients[95] = new Cliente(25, 24, 20);
        clients[29] = new Cliente(64, 42, 9);
        clients[63] = new Cliente(27, 69, 10);
        clients[96] = new Cliente(22, 27, 11);
        clients[30] = new Cliente(40, 60, 21);
        clients[64] = new Cliente(15, 77, 9);
        clients[97] = new Cliente(25, 21, 12);
        clients[31] = new Cliente(31, 52, 27);
        clients[65] = new Cliente(62, 77, 20);
        clients[98] = new Cliente(19, 21, 10);
        clients[32] = new Cliente(35, 69, 23);
        clients[66] = new Cliente(49, 73, 25);
        clients[99] = new Cliente(20, 26, 9);
        clients[33] = new Cliente(53, 52, 11);
        clients[67] = new Cliente(67, 5, 25);
        clients[100] = new Cliente(18, 18, 17);
        clients[34] = new Cliente(65, 55, 14);

        return clients;
    }

}
