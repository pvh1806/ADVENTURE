using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Musicmanager : MonoBehaviour
{
    int nextScene;
    // Start is called before the first frame update
    void Awake()
    {
       
            DontDestroyOnLoad(gameObject);
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.buildIndex < 0 || scene.buildIndex > 3)
        {
            Destroy(gameObject);
        }
    }
}
