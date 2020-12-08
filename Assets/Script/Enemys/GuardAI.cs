using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    NavMeshAgent guardNav;

    public List<Transform> listWayPoint;
    public bool perseguir;
    public GameObject player;

    int i = 0;
    bool adelante = true;
    bool wait = false;
    bool atacando = false;
    public float distanciaPerseguir = 4f;
    public float speed = 3;
    public float speedPerseguir = 4;


    public int vida = 2;
    
    [HideInInspector]
    public bool atacado;

    Animator anim;
    AudioSource audioSource;
    public AudioClip dano;
    public AudioClip muerte;
    public AudioClip audioAtacar;
    public AudioClip audioPatrullar;


    private void Start()
    {
        guardNav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        anim.SetBool(Animaciones.PATRULLAR, false);
        perseguir = false;
        atacado = false;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, listWayPoint[i].position);
        int tamLista = listWayPoint.Count;

        float distanciaDelJugador = Vector3.Distance(transform.position, player.transform.position);

        // si el personaje esta cerca, el personaje le perseguira
        if (distanciaDelJugador < distanciaPerseguir)
        {
            perseguir = true;
        }

        // Si perseguir es falso, el personaje patrullara una zona
        if (!perseguir)
        {
            guardNav.SetDestination(listWayPoint[i].position);
            guardNav.speed = speed;
            if (distance < 1.5f && wait == false)
            {
                wait = true;
                if (listWayPoint.Count > 1 && listWayPoint[i] != null)
                {
                    StartCoroutine(MueveGuardia());
                }
            }
        } // Si perseguir es verdadero, el personaje ira hacia la posicion del personaje
        else
        {

            guardNav.speed = speedPerseguir;
            anim.SetBool(Animaciones.PATRULLAR, false);
            anim.SetBool(Animaciones.PERSEGUIR, true);
            if (!atacando)
            {
                guardNav.SetDestination(player.transform.position);
            }
            
            if (distanciaDelJugador < 1.7f && !atacando && vida != 0) 
            {
                atacando = true;
                Invoke("Atacar", 0.1f);
            }

            if (distanciaDelJugador > distanciaPerseguir)
            {
                anim.SetBool(Animaciones.PERSEGUIR, false);
                anim.SetBool(Animaciones.PATRULLAR, true);
                perseguir = false;
                wait = false;
            }

        }

    }


    void Atacar()
    {
        //quitar vida al player
        player.SendMessage("AtacarPlayer", 1f);
        //hacer sonido de ataque
        audioSource.clip = audioAtacar;
        audioSource.Play();
        anim.SetBool("ataque", true);
        Invoke("DejarDeAtacar", 1.5f);
    }

    void DejarDeAtacar()
    {
        atacando = false;
        audioSource.clip = audioPatrullar;
        audioSource.Play();
        anim.SetBool("ataque", false);
    }

    IEnumerator MueveGuardia()
    {
        if (i == 0 || i + 1 == listWayPoint.Count)
        {
            anim.SetBool(Animaciones.PATRULLAR, false);
            yield return new WaitForSeconds(1f);
        }

        if (wait)
        {
            anim.SetBool(Animaciones.PATRULLAR, true);
            if (i + 1 == listWayPoint.Count && listWayPoint.Count > 1)
                adelante = false;
            else if (i == 0 && listWayPoint.Count > 1)
                adelante = true;

            if (listWayPoint.Count > 1 && adelante)
                i++;
            else if (listWayPoint.Count > 1 && i != 0 && !adelante)
                i--;

            wait = false;
        }


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
                    audioSource.clip = muerte;
                    audioSource.Play();
                    anim.SetTrigger("die");
                    Destroy(this.gameObject, 2f);
                    Invoke("NoAtacado", 2f);
                }
                else
                {
                    audioSource.clip = dano;
                    audioSource.Play();
                    anim.SetBool("dano", true);
                    Invoke("NoAtacado", 0.7f);
                }

            }
        }

    }

    void NoAtacado()
    {
        anim.SetBool("dano", false);
        atacado = false;
        audioSource.Stop();
    }
}
