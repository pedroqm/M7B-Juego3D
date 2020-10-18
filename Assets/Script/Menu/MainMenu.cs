using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject fadeOff;

    public void StartGame()
    {

        fadeOff.SetActive(true);
        Invoke("EmpezarPartida", 2f);
    }

    void EmpezarPartida()
    {
        SceneManager.LoadScene(Levels.SELECTLEVEL);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
