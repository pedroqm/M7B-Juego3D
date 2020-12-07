﻿using System.Collections;
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

    Animator anim;
    AudioSource audioSource;
    public AudioClip audioAtacar;
    public AudioClip audioPatrullar;

    private void Start()
    {
        guardNav = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();

        anim.SetBool(Animaciones.PATRULLAR, false);
        perseguir = false;
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
            //Debug.Log("Distancia del punto : " + distance);
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
            anim.SetBool(Animaciones.PATRULLAR, false);
            anim.SetBool(Animaciones.PERSEGUIR, true);
            guardNav.SetDestination(player.transform.position);

            if (distanciaDelJugador < 1.5f && !atacando) 
            {
                atacando = true;
                Invoke("Atacar", 0.5f);
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
        Debug.Log("Ataca");
        player.SendMessage("AtacarPlayer", 1f);
        audioSource.clip = audioAtacar;
        audioSource.Play();
        //quitar vida al player
        //hacer sonido de ataque
        Invoke("DejarDeAtacar", 1);
    }

    void DejarDeAtacar()
    {
        atacando = false;
        audioSource.clip = audioPatrullar;
        audioSource.Play();
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
}
