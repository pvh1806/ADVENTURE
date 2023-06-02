using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionLeve : MonoBehaviour
{
    public Button[] SelectBtn;
    public int dem;
    // Start is called before the first frame update
    void Start()
    {   PlayerPrefs.SetInt("LevelAt", 5);
        int levelAt = PlayerPrefs.GetInt("LevelAt");
        dem = 0;
        for (int i = 0; i < SelectBtn.Length; i++)
        {
            if (i + 4 > levelAt)
            {
                SelectBtn[i].interactable = false;
            }
        }
    }
    // Update is called once per frame
    public void LoadScenes1()
    {
        SceneManager.LoadScene("Leve1");
    }
    public void LoadScenes2()
    {
        dem++;
        if (dem == 3)
        {
            SceneManager.LoadScene("Leve2");
        }
    }
    public void LoadScenes3()
    {
        SceneManager.LoadScene("Leve3");
    }
}
