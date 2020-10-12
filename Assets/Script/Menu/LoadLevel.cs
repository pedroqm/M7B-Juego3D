using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public Image progressBar;
    public string pantallaACargar;

    // Start is called before the first frame update
    void Start()
    {
        // call coroutine to load the main menu
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        //create an asybc operation = loadSceneAsync
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
