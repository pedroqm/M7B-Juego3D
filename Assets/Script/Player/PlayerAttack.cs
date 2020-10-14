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
        if (Input.GetKeyDown(KeyCode.Mouse0) && canAttack)
        {
            Debug.Log(canAttack);
            source.GenerateImpulse(Camera.main.transform.forward);
            canAttack = false;
            anim.SetBool("Attack", true);
            Invoke("StopAttack",0.7f);
        }
    }

    void StopAttack()
    {
        canAttack = true;
        anim.SetBool("Attack", false);
    }
}
