using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject fadeOff;
    public GameObject canvasInstrucciones;

    private void Awake()
    {
        fadeOff.SetActive(false);
    }

    public void StartGame()
    {

        fadeOff.SetActive(true);
        EmpezarPartida();
    }

    void EmpezarPartida()
    {
        SceneManager.LoadScene(Levels.SELECTLEVEL);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Instrucciones()
    {
        canvasInstrucciones.SetActive(true);
    }
    public void Volver()
    {
        canvasInstrucciones.SetActive(false);
    }

}
