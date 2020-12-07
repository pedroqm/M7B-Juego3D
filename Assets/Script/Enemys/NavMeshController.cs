using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    NavMeshAgent agente;

    //public List<Transform> listWayPoint;
    public GameObject player;

    int i = 0;
    bool adelante = true;
    bool wait = false;
    bool atacando = false;
    public float distanciaPerseguir = 4f;
    public float speed = 3;
    public float speedPerseguir = 6;

    Animator anim;
    AudioSource audioSource;
    public AudioClip audioAtacar;
    public AudioClip[] audioPatrullar;
    public AudioClip audioRespirar;


    private void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        //float distance = Vector3.Distance(transform.position, listWayPoint[i].position);
        //int tamLista = listWayPoint.Count;

        float distance = Vector3.Distance(agente.transform.position, player.transform.position);
        if (distance < 20f)
        {
            agente.speed = speedPerseguir;
            anim.SetTrigger("run");
        }
        else
        {
            anim.SetTrigger("walk");
            agente.speed = speed;
        }

        float distanciaDelJugador = Vector3.Distance(transform.position, player.transform.position);

        // si el personaje esta cerca, el personaje le perseguira
               
            if (!atacando)
            {
                agente.SetDestination(player.transform.position);
            }

            if (distanciaDelJugador < 3f && !atacando)
            {
                atacando = true;
                Invoke("Atacar", 0.1f);
            }

    }


    void Atacar()
    {
        Debug.Log("Ataca");
        //quitar vida al player
        player.SendMessage("AtacarPlayer", 10f);
        //hacer sonido de ataque
        audioSource.clip = audioAtacar;
        audioSource.Play();
        Invoke("DejarDeAtacar", 1);
    }

    void DejarDeAtacar()
    {
        atacando = false;
        audioSource.clip = audioRespirar;
        audioSource.Play();
    }

}
