using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLifePoint : MonoBehaviour
{
    public int vida = 2;
    //public float impulso;
    public AudioClip dano;
    public AudioClip muerte;
    AudioSource audioEnemy;
    [HideInInspector]
    public bool atacado;

    private void Start()
    {
        atacado = false;
        audioEnemy = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == Tags.WEAPON)
        {
       
            if (!atacado)
            {
                //GameObject player = GameObject.FindGameObjectWithTag(Tags.PLAYER).gameObject;
                //GetComponent<Rigidbody>().AddForce(player.transform.forward * impulso, ForceMode.Impulse);
                print("pierde vida");
                atacado = true;
                vida--;
                
                if (vida <= 0)
                {
                    audioEnemy.clip = muerte;
                    audioEnemy.Play();
                    Destroy(this.gameObject, 0.7f);
                }
                else
                {
                    audioEnemy.clip = dano;
                    audioEnemy.Play();
                }
                Invoke("NoAtacado", 0.7f);
            }
        }

    }

    void NoAtacado()
    {
        atacado = false;
        audioEnemy.Stop();
    }
}
