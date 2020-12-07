using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Cinemachine.CinemachineImpulseSource source;
    Animator anim;
    [HideInInspector]
    public bool canAttack = true;
    public BoxCollider weapon;

    public AudioClip weaponAttack;
    AudioSource audioPlayer;

    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        audioPlayer = GetComponent<AudioSource>();
        canAttack = true;
    }

    void Update()
    {
        if (canAttack && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            source.GenerateImpulse(Camera.main.transform.forward);
            canAttack = false;
            audioPlayer.clip = weaponAttack;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
               
                weapon.enabled = true;
                audioPlayer.Play();
                anim.SetTrigger("Attack1");
                Invoke("StopAttack", 0.7f);
            }
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                weapon.enabled = true;
                audioPlayer.Play();
                anim.SetTrigger("Attack2");
                Invoke("StopAttack", 1.2f);
            }
            anim.SetBool("Attack", true);
        }
    }

    void StopAttack()
    {
        weapon.enabled = false;
        canAttack = true;
        anim.SetBool("Attack", false);
        
    }
}
