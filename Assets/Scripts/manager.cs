using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour
{
    public static float coin_total; //全体のコインの量
    public GameObject coin_object = null;
    [SerializeField] public List<GameObject> character; //キャラクターのスキン情報が入っているリスト
    // Start is called before the first frame update
    void Start()
    {
        coin_total = PlayerPrefs.GetFloat("coin", 0);
        //firstloadが1でないなら
        if(SkinManagerx.firstload != 1)
        {
            for(int i = 0;i < SkinManagerx.SKIN_LIMIT;i++)
            {
                SkinManagerx.chara.Insert(i, 0);    //firstcharaのリストに0を入れる
            }
            SkinManagerx.chara[0] = 1;  //0番目を1にする
            PlayerPrefsUtility.SaveList<int>("select_chara", SkinManagerx.chara);   //charaをセーブする
        }
        List<int> loadChara = PlayerPrefsUtility.LoadList<int>("select_chara"); //loadCharaのリストにcharaのリストの情報を入れる
        for (int i = 0;i <SkinManagerx.SKIN_LIMIT;i++)
        {
            if(loadChara[i] == 1)
            {
                Instantiate(character[i], new Vector3(0, 0.6f, -4),Quaternion.identity);   //キャラクターを生成する
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Text coin_text = coin_object.GetComponent<Text>();
        coin_text.text = "coin:" + Pmove.coin_get;  //右上にゲーム中に取得したコイン数を表示する
    }
}
