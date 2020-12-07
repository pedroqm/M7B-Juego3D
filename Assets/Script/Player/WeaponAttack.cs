using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{

    public GameObject weapon;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.ENEMY)
        {
            Debug.Log("Restar vida");
           // other.GetComponent<EnemyLifePoint>().SendMessage("QuitarVida", 1);
        }
    }
}
