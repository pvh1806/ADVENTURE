using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class Vacham : MonoBehaviour
{
    public GameObject die;
    public GameObject menudie;
    public GameObject menupause;
    Rigidbody2D Nv;
    public static float speedBrowm;
    public Image health;
    Animator ani;
    public TextMeshProUGUI[] point;
    int dem;
    int[] arr = { 0, 0, 0, 0, 0 };
    bool KtHit = false;
    public AudioSource[] audio;
    public Button ButtonPause;
    // Start is called before the first frame update
    private void Start()
    {
        Nv = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        speedBrowm = 1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap" || collision.gameObject.tag == "Rangcua" || collision.gameObject.tag == "Quaivat" || collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Flower" || collision.gameObject.tag == "EnemyAi")
        {
            audio[0].Play();
            health.fillAmount = health.fillAmount - SetLevel.dame;
            KtHit = true;
            ani.SetBool("KtHit", KtHit);
            Invoke("ReturnToNormal", 2f);
            Nv.velocity = new Vector2(Nv.velocity.x, 7f);
        }
        if (collision.gameObject.tag == "Jump")
        {
            Nv.velocity = new Vector2(Nv.velocity.x, 10f);
        }
        if (collision.gameObject.tag == "Xich")
        {
            audio[0].Play();
            health.fillAmount = health.fillAmount - SetLevel.dame;
            KtHit = true;
            ani.SetBool("KtHit", KtHit);
            Invoke("ReturnToNormal", 2f);
            Destroy(collision.gameObject);
            Nv.velocity = new Vector2(Nv.velocity.x, 7f);
        }
        if (health.fillAmount == 0)
        {
            die.SetActive(true);
            audio[2].Play();
            audio[3].Stop();
            Invoke("loaddie", 5f);
            Nv.bodyType = RigidbodyType2D.Static;
            ani.enabled = false;
            SetLevel.speed = 0;
        }
    }
    void loaddie()
    {
        die.SetActive(false);
        menudie.SetActive(true);
        ButtonPause.interactable = false;

        if (dem >= PlayerPrefs.GetInt("arr" + 4) && dem != PlayerPrefs.GetInt("arr" + 0) && dem != PlayerPrefs.GetInt("arr" + 1) && dem != PlayerPrefs.GetInt("arr" + 2) && dem != PlayerPrefs.GetInt("arr" + 3))
        {

            PlayerPrefs.SetInt("arr" + 4, dem);
            point[2].text = "best new :" + " " + PlayerPrefs.GetInt("arr" + 4);
            int[] b = { PlayerPrefs.GetInt("arr" + 0, arr[0]), PlayerPrefs.GetInt("arr" + 1, arr[1]), PlayerPrefs.GetInt("arr" + 2, arr[3]), PlayerPrefs.GetInt("arr" + 3, arr[3]), PlayerPrefs.GetInt("arr" + 4, arr[4]) };
            Array.Sort(b);
            Array.Reverse(b);
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt("arr" + i, b[i]);
                b[i] = PlayerPrefs.GetInt("arr" + i);

            }

        }
        else
        {
            point[2].text = "best :" + " " + PlayerPrefs.GetInt("arr" + 0);
        }
    }
    private void ReturnToNormal()
    {
        KtHit = false;
        ani.SetBool("KtHit", KtHit);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Apple" || collision.gameObject.tag == "Cherry")
        {
            audio[1].Play();
            dem = dem + 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Banana")
        {
            audio[1].Play();
            dem = dem + 3;
            Destroy(collision.gameObject);
        }
        point[0].text = "Point :" + " " + dem.ToString();
        point[1].text = point[0].text;
    }
    public void pauseMenu()
    {
        menupause.SetActive(true);
        ButtonPause.interactable = false;
        Time.timeScale = 0;
    }
    public void resume()
    {
        menupause.SetActive(false);
        Time.timeScale = 1;
        ButtonPause.interactable = true;
    }
    public void home()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
