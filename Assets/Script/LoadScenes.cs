using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour

{
    public string Name;
    public string Name1;
    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene(Name);
    }
    public void LoadScene1()
    {
        SceneManager.LoadScene(Name1);
    }
}
