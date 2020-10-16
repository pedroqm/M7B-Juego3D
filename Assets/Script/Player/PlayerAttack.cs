using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
     Cinemachine.CinemachineImpulseSource source;
    Animator anim;
    [HideInInspector]
    public bool canAttack = true;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack && (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)))
        {
            Debug.Log(canAttack);
            source.GenerateImpulse(Camera.main.transform.forward);
            canAttack = false;
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {                
                anim.SetTrigger("Attack1");
                Invoke("StopAttack", 0.7f);
            }
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                anim.SetTrigger("Attack2");
                Invoke("StopAttack", 1.2f);
            }
            anim.SetBool("Attack", true);
        }
    }

    void StopAttack()
    {
        canAttack = true;
        anim.SetBool("Attack", false);
        //anim.Play("Idle");
    }
}
