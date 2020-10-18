using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprint : MonoBehaviour
{

    private PlayerMovement playerMovement;

    public float sprint_Speed;
    public float move_Speed;

    Animator anim;

    private PlayerFootsteps player_Footsteps;

    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min = 0.2f, walk_Volume_Max = 0.6f;

    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;


    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();

        player_Footsteps = GetComponent<PlayerFootsteps>();
    }
    void Start()
    {
        player_Footsteps.volume_Min = walk_Volume_Min;
        player_Footsteps.volume_Max = walk_Volume_Max;
        player_Footsteps.step_Distance = walk_Step_Distance;
    }
    void Update()
    {
        Sprint();
    }

    void Sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && playerMovement.walking)
        {
            playerMovement.speed = sprint_Speed;
            anim.SetBool("IsSprint", true);
            anim.SetBool("IsWalking", false);

            player_Footsteps.step_Distance = sprint_Step_Distance;
            player_Footsteps.volume_Min = sprint_Volume;
            player_Footsteps.volume_Max = sprint_Volume;

        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            playerMovement.speed = move_Speed;
            anim.SetBool("IsSprint", false);
            anim.SetBool("IsWalking", true);

            player_Footsteps.step_Distance = walk_Step_Distance;
            player_Footsteps.volume_Min = walk_Volume_Min;
            player_Footsteps.volume_Max = walk_Volume_Max;

        }
    } // sprint

}
