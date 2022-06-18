using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pmove : MonoBehaviour
{
    [SerializeField] public float speed = 7; //前進スピード
    [SerializeField] public float movespeed = 4; //左右スピード
    public static float coin_get = 0;   //一時的なコイン
    public static double height = 1;  //キャラの高さ
    public AudioClip milk;
    public AudioClip bad;
    public AudioClip coin;
    AudioSource As;

    // Start is called before the first frame update
    void Start()
    {
        As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, speed) * Time.deltaTime;    //前に進む
        //右矢印を押したら右に行く
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < 2)
            {
                transform.position = transform.position + new Vector3(movespeed, 0, 0) * Time.deltaTime;
            }
        }
        //左矢印を押したら左に行く
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (-2 < transform.position.x)
            {
                transform.position = transform.position - new Vector3(movespeed, 0, 0) * Time.deltaTime;
            }
        }
        //高さが0.8以下になったらゲームオーバー
        if (0.8 > transform.localScale.y)
        {
            PlayerPrefs.SetFloat("coin", manager.coin_total + coin_get);
            PlayerPrefs.Save();
            SceneManager.LoadScene("GameOverScene");
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        //タグがmilkなら背が高くなる
        if (other.gameObject.tag == "milk")
        {
            As.PlayOneShot(milk);
            transform.localScale = transform.localScale + new Vector3(0, (float)0.3, 0);
            height += 0.3;
            Destroy(other.gameObject);
        }
        //タグがbadなら背が小さくなる
        else if (other.gameObject.tag == "bad")
        {
            As.PlayOneShot(bad);
            transform.localScale = transform.localScale + new Vector3(0, (float)-0.3, 0);
            height -= 0.3;
            Destroy(other.gameObject);
        }
        //タグがCoinならコインが増える
        else if (other.gameObject.tag == "Coin")
        {
            As.PlayOneShot(coin);
            coin_get += 1;
            Destroy(other.gameObject);
        }
    }
}
