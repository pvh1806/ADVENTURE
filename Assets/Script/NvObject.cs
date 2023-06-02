using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NvObject : MonoBehaviour
{
    SpriteRenderer LoadNhanVat;
    Animator LoadAniNhanVat;
    public SpriteRenderer LoadNhanVat1;
    public Animator LoadAniNhanVat1;
    // Start is called before the first frame update
    void Start()
    {
        LoadAniNhanVat = GetComponent<Animator>();
        LoadNhanVat = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadNhanVat.sprite = LoadNhanVat1.sprite;
        LoadAniNhanVat.runtimeAnimatorController = LoadAniNhanVat1.runtimeAnimatorController;
    }
}
