using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour {

    private AudioSource footstep_Sound;

    [SerializeField]
    private AudioClip[] footstep_Clip;

    private PlayerMovement character;

    [HideInInspector]
    public float volume_Min, volume_Max;

    private float accumulated_Distance;

    [HideInInspector]
    public float step_Distance;

	void Awake () {
        footstep_Sound = GetComponent<AudioSource>();

        character = GetComponent<PlayerMovement>();
	}
	
	void Update () {
        CheckToPlayFootstepSound();	
	}

    void CheckToPlayFootstepSound() {
            

        if(character.walking) {

            // accumulated distance is the value how far can we go 
            accumulated_Distance += Time.deltaTime;

            if(accumulated_Distance > step_Distance) {

                footstep_Sound.volume = Random.Range(volume_Min, volume_Max);
                footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];
                footstep_Sound.Play();

                accumulated_Distance = 0f;

            }

        } else {
            accumulated_Distance = 0f;
        }
    }
} // class


































