using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI[] bestpoint;
    public void highscore()
    {
        for(int i = 0;i<5;i++) {
            bestpoint[i].text = "TOP "+ (i+1) + ":" +" " +PlayerPrefs.GetInt("arr" + i);
        }
    }
}
