using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public GameObject loadingCanvas;
    public GameObject selectLevelCanvas;
    public Image progressBar;
    private string pantallaACargar;

    // Start is called before the first frame update
    void Start()
    {
        // call coroutine to load the main menu
        StartCoroutine(LoadLevelAsync());
    }

    public void Level1()
    {
        loadingCanvas.SetActive(true);
        selectLevelCanvas.SetActive(false);
        pantallaACargar = Levels.LEVEL_1;
        StartCoroutine("LoadLevelAsync");
    }
    public void Level2()
    {
        loadingCanvas.SetActive(true);
        selectLevelCanvas.SetActive(false);
        pantallaACargar = Levels.LEVEL_2;
        StartCoroutine("LoadLevelAsync");
    }

    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator LoadLevelAsync()
    {
        if (pantallaACargar != null)
        {
            //create an asyn operation = loadSceneAsync
            AsyncOperation operation = SceneManager.LoadSceneAsync(pantallaACargar);
            //while operation ins´t finished
            while (!operation.isDone)
            {
                // progress bar fill amount = operation progress
                progressBar.fillAmount = operation.progress;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
