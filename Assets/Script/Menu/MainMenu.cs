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
}
