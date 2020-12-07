using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifePoint : MonoBehaviour
{
    public int vidaMax;
    public Slider sliderVida;
    int vida;
    public GameObject panelGameOver;
    Cinemachine.CinemachineImpulseSource source;

    private void Awake()
    {
        vida = vidaMax;
        sliderVida.maxValue = vidaMax;
        sliderVida.value = vida;
        source = GetComponent<Cinemachine.CinemachineImpulseSource>();
    }

    void AtacarPlayer(int danoRecibido)
    {
        vida -= danoRecibido;
        sliderVida.value = vida;
        source.GenerateImpulse(Camera.main.transform.forward);

        if (vida <= 0)
        {
            // GAMEOVER
            Debug.Log("Game Over");
            panelGameOver.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
