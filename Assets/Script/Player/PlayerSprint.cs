using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{

    private PlayerMovement playerMovement;

    public float sprint_Speed;
    public float move_Speed;

    Animator anim;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Sprint();
    }

    void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && playerMovement.walking)
        {
            playerMovement.speed = sprint_Speed;
            anim.SetBool("IsSprint", true);
            anim.SetBool("IsWalking", false);

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            playerMovement.speed = move_Speed;
            anim.SetBool("IsSprint", false);
            anim.SetBool("IsWalking", true);

        }
    } // sprint

}
