using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetLevel : MonoBehaviour
{
    public static int speed;
    public static float dame;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    public void easy()
    {
        speed = 2;
        dame = 0.2f;
        Destroy(text);
    }
    public void hard()
    {
        speed = 4;
        dame = 0.25f;
        Destroy(text);
    }
    public void PlayGame()
    {
        if (speed == 0)
        {
            text.text = "Select level before playgame";
        }
        else
        {
            SceneManager.LoadScene("SelectLv");
        }
    }
}
