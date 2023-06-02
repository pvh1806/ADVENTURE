using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    private Scene currentScene;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(enemy);
        SceneManager.sceneLoaded += OnSceneLoaded;
        currentScene = SceneManager.GetActiveScene();
        OnSceneLoaded(currentScene, LoadSceneMode.Single);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "SelectLv")
        {
            gameObject.SetActive(false);
        }
        else if (scene.buildIndex >= 4)
        {
            gameObject.SetActive(true);
        }
        if (enemy != null)
        {
            enemy.transform.position = new Vector3(-16.6f, 4f, 0f);
        }

        currentScene = scene;

        if (scene.buildIndex < 0 || scene.buildIndex < 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
