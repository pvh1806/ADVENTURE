using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MuteAudio : MonoBehaviour
{
    SpriteRenderer Spp;
    public Sprite[] Sp;
    public float x;
    public AudioMixer audioMixer;
    bool Kt;
    // Start is called before the first frame update
    void Start()
    {
        Spp = GetComponent<SpriteRenderer>();
    }
    private void Awake()
    {
        Kt = true;
    }
    private void Update()
    {
        audioMixer.GetFloat("Volume", out x);
        if (x == 0) {
            Spp.sprite = Sp[0];
        }
        if (x == -80)
        {
            Spp.sprite = Sp[1];
        }
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        if(Kt== true)
        {
            audioMixer.SetFloat("Volume", -80);
            Kt= false;
        }
        else
        {
            audioMixer.SetFloat("Volume", 0);
            Kt = true;
        }
    }
}
