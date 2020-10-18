using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public AudioClip clip;
    AudioManager audioManager;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("GameManager is null!");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;

    }

    private void Start()
    {
        AudioManager.Instance.PlayMusic(clip);
    }

    public void Update()
    {
        
    }
}
