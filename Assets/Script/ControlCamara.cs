using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{
    public float velocidadDeRotacion = 1.0f;
    public Transform objetivo, personaje;
    private float mouseX, mouseY;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        ControlDeCamara();
    }

    void ControlDeCamara()
    {
        mouseX += Input.GetAxis(Axis.MOUSEX) * velocidadDeRotacion;
        mouseY += Input.GetAxis(Axis.MOUSEY) * velocidadDeRotacion;

        mouseY = Mathf.Clamp(mouseY, -10, 10);

        transform.LookAt(objetivo);
        objetivo.rotation = Quaternion.Euler(-mouseY, mouseX, 0) * Quaternion.identity;
        personaje.rotation = Quaternion.Euler(0, mouseX, 0) * Quaternion.identity;
        
    }
}
