using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject fadeIn;
    public GameObject fadeOff;
    public GameObject canvasInstrucciones;

    private void Start()
    {
       
        fadeIn.SetActive(true);
        fadeOff.SetActive(false);
    }
   
    public void StartGame()
    {
        fadeIn.SetActive(false);
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
