using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed, smooth;
    Animator anim;
    Rigidbody rb;
    Vector3 movement;

    PlayerAttack playerAttack;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    //USAMOS FIXEDUPDATE PORQUE VAMOS A HACER EL MOVIMIENTO MEDIANTE FÍSICAS
    void FixedUpdate()
    {
        //GetAxis devuelve valores entre -1 y 1 
        //GetAxisRaw devuelve solo 3 valores: -1, 0, 1.

        if (playerAttack.canAttack)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            float g = Input.GetAxisRaw("Girar");
            Move(h, v, g);


            Animation(h, v);
        }
    }
  
    void Move(float _h, float _v, float _g)
    {       
        transform.Translate(Vector3.forward * _v * speed * Time.deltaTime);
        transform.Translate(Vector3.right * _h * speed * Time.deltaTime);
        transform.Rotate(Vector3.up * _g * smooth * Time.deltaTime);
    }

    void Animation(float _h, float _v)
    {

        bool walking = _h != 0f || _v != 0f;
        anim.SetBool("IsWalking", walking);
    }

}
