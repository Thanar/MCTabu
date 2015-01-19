using UnityEngine;
using System.Collections;

public class Cliente {
    public int x = 0;
    public int y = 0;
    public float q = float.MaxValue;

    public Cliente(int x, int y, int q)
    {
        this.x = x;
        this.y = y;
        this.q = q;
    }
}
