using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class coinUI : MonoBehaviour
{
    
    public GameObject coin_object2 = null;
    public GameObject coin_object = null;
    // Start is called before the first frame update
    void Start()
    {
        Text coin_text = coin_object.GetComponent<Text>();
        coin_text.text = "coin:" + Pmove.coin_get;  //ゲーム中に取得したコインを表示する
        Text coin_text2 = coin_object2.GetComponent<Text>();
        coin_text2.text = "totalcoin:" + manager.coin_total;    //全体のコイン数を表示する
    }

    // Update is called once per frame
    void Update()
    {
        Pmove.coin_get = 0;
    }
}
