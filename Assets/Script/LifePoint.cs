using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePoint : MonoBehaviour
{
    public int vidaMax;
    int vida;

    private void Start()
    {
        int vida = vidaMax;
    }

    void Atacar(int danoRecibido)
    {
        vida -= danoRecibido;

        if (vida <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
