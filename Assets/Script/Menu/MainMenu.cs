using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject fadeOff;

    private void Awake()
    {
        fadeOff.SetActive(false);
    }

    public void StartGame()
    {

        fadeOff.SetActive(true);
        Invoke("EmpezarPartida", 1.5f);
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
