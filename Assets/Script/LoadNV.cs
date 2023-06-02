using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadNV : MonoBehaviour
{
    SpriteRenderer LoadNhanVat;
    Animator LoadAniNhanVat;
    public SpriteRenderer[] LoadNhanVat1;
    public Animator[] LoadAniNhanVat1;
    public GameObject[] Nv;
    public GameObject player;
    int index = 0;
    public TextMeshProUGUI NameCharactor;
    private void Start()
    {
        LoadAniNhanVat = GetComponent<Animator>();
        LoadNhanVat = GetComponent<SpriteRenderer>();
        LoadNhanVat.sprite = LoadNhanVat1[0].sprite;
        LoadAniNhanVat.runtimeAnimatorController = LoadAniNhanVat1[0].runtimeAnimatorController;
        NameCharactor.text = Nv[0].tag;
    }
    public void Next()
    {
        SceneManager.LoadScene("SelectLevel");
        SetLevel.speed = 0;
        PrefabUtility.SaveAsPrefabAsset(player, "Assets/prefab/player.prefab");
    }
    public void Selectback()
    {  if(index >= 0)
        {
            index--;
        }
        if (index == -1)
        {
            index = LoadAniNhanVat1.Length -1;
        }
        LoadNhanVat.sprite = LoadNhanVat1[index].sprite;
        LoadAniNhanVat.runtimeAnimatorController = LoadAniNhanVat1[index].runtimeAnimatorController;
        NameCharactor.text = Nv[index].tag;
    }
    public void Selectnext()
    { if(index <= LoadAniNhanVat1.Length -1)
        {
            index++;
        }
        if (index == LoadAniNhanVat1.Length  )
        {
            index = 0;
        }
        LoadNhanVat.sprite = LoadNhanVat1[index].sprite;
        LoadAniNhanVat.runtimeAnimatorController = LoadAniNhanVat1[index].runtimeAnimatorController;
        NameCharactor.text = Nv[index].tag;
    }
}
