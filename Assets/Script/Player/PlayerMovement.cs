using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerMovement : MonoBehaviour
{

    public float speed, smooth, gravity;
    Animator anim;
    Rigidbody rb;
    Vector3 movement;
    public GameObject panelWin;

    PlayerAttack playerAttack;

    public bool walking =false;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerAttack = GetComponent<PlayerAttack>();
        Time.timeScale = 1;
    }

    //USAMOS FIXEDUPDATE PORQUE VAMOS A HACER EL MOVIMIENTO MEDIANTE FISICAS
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
        //transform.Translate(Vector3.forward * _v * speed * Time.deltaTime);
        //transform.Translate(Vector3.right * _h * speed * Time.deltaTime);
        //transform.Rotate(Vector3.up * _g * smooth * Time.deltaTime);

        Vector3 movimientoFrontal = transform.forward * speed * _v;
        Vector3 movimientoLateral = transform.right * speed * _h;
        Vector3 velocidadVertical = new Vector3(0, rb.velocity.y, 0);

        rb.velocity = movimientoFrontal + movimientoLateral + velocidadVertical;
    }

    void Animation(float _h, float _v)
    {

        walking = _h != 0f || _v != 0f;
        anim.SetBool("IsWalking", walking);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Exit"))
        {
            panelWin.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
