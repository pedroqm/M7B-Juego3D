using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int speed, smooth, angle;
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
            Move(h, v);


            Animation(h, v);
        }
    }
  
    void Move(float _h, float _v)
    {
        movement.Set(_h, 0, _v); //Establecemos la variable Vector3 movement en base a los input
        movement = movement.normalized * speed * Time.deltaTime; //normalizamos el vector3 movement y multiplicamos por la velocidad
        rb.MovePosition(transform.position + movement); //Movemos el player sumandole a su posicion actual el vector movimiento

        /*
        transform.Translate(Vector3.forward * v * speed * Time.deltaTime);
        transform.Translate(Vector3.right * h * speed * Time.deltaTime);
        */


       /* if (Input.GetKey(KeyCode.Q))
        {
            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, -1 * angle, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
            //Quaternion.AngleAxis;
        }
        if (Input.GetKey(KeyCode.E))
        {
            // Rotate the cube by converting the angles into a quaternion.
            Quaternion target = Quaternion.Euler(0, angle, 0);

            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }*/

    }

    void Animation(float _h, float _v)
    {

        bool walking = _h != 0f || _v != 0f;
        anim.SetBool("IsWalking", walking);
    }

}
