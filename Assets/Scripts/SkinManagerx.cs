using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManagerx : MonoBehaviour
{
    [SerializeField]List<GameObject> lockbutton;    //lockbuttonのリスト
    [SerializeField]List<GameObject> selectbutton;  //selectbuttonのリスト
    [SerializeField] List<GameObject> preview;
    [SerializeField] public float price = 500;    //スキン解放に必要なコイン数
    public static List<int> chara = new List<int>();    //スキン選択の一時的なリスト
    public static List<int> skins = new List<int>();    //スキン解放の一時的なリスト
    public static int SKIN_LIMIT = 9;   //スキン数
    public static int firstload;    //初回読み込み用の変数
    int randomunlock;   //ランダムアンロック用の変数

    // Start is called before the first frame update
    void Start()
    {   
        firstload = PlayerPrefs.GetInt("firstx", 0);
        //firstloadが1でないなら
        if (firstload != 1)
        {
            PlayerPrefs.SetInt("firstx", 1);
            PlayerPrefs.Save();
            //skinsのリストとcharaのリストに0を入れる
            for (int i = 0; i < SKIN_LIMIT; i++)
            {
                skins.Insert(i,0);
                chara.Insert(i,0);
            }
            
            chara[0] = 1;   //0番目だけ1にする
            skins[0] = 1;   //0番目だけ1にする
            PlayerPrefsUtility.SaveList<int>("unlock_skins", skins);    //skinsのリストをセーブする
        }
        List<int> loadList = PlayerPrefsUtility.LoadList<int>("unlock_skins"); //loadListのリストにセーブされたskinsのリスト情報を入れる
        skins = loadList;   //skinsのリストにloadListのリスト情報を入れる
        for (int j = 0;j < SKIN_LIMIT; j++)
        {
            //skin[j]が1ならセレクトボタンアンロック
            if (skins[j] == 1)
            {
                lockbutton[j].SetActive(false);
                selectbutton[j].SetActive(true);
            }
            //skin[j]が０ならセレクトボタンロック
            else
            {
                lockbutton[j].SetActive(true);
                selectbutton[j].SetActive(false);
            }
            
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RandomUnlock()
    {
        //コインがpriceより多かったら
        if(manager.coin_total >= price)
        {
            while (true)
            {
                randomunlock = Random.Range(0, SKIN_LIMIT); //0から8のランダムな値を生成
                //skin[randomunlock]が0ならセレクトボタンアンロック
                if (skins[randomunlock] == 0)
                {
                    skins[randomunlock] = 1;
                    lockbutton[randomunlock].SetActive(false);
                    selectbutton[randomunlock].SetActive(true);
                    PlayerPrefsUtility.SaveList<int>("unlock_skins", skins);    //skinsをセーブする
                    PlayerPrefs.SetFloat("coin", manager.coin_total - price);   //全体のコインからprice分のコインを引く
                    PlayerPrefs.Save();
                    manager.coin_total = PlayerPrefs.GetFloat("coin", 0);
                    break;
                }
            }
            
        }
        
    }

    public void selectchara0()
    {
        for(int i = 0; i < SKIN_LIMIT;i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[0].SetActive(true);
        chara[0] = 1;   //chara[0]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara1()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[1].SetActive(true);
        chara[1] = 1;   //chara[1]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara2()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[2].SetActive(true);
        chara[2] = 1;   //chara[2]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara3()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[3].SetActive(true);
        chara[3] = 1;   //chara[3]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara4()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[4].SetActive(true);
        chara[4] = 1;   //chara[4]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara5()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[5].SetActive(true);
        chara[5] = 1;   //chara[5]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara6()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[6].SetActive(true);
        chara[6] = 1;   //chara[6]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara7()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[7].SetActive(true);
        chara[7] = 1;   //chara[7]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }

    public void selectchara8()
    {
        for (int i = 0; i < SKIN_LIMIT; i++)
        {
            chara.Insert(i, 0);
            preview[i].SetActive(false);
        }
        preview[8].SetActive(true);
        chara[8] = 1;   //chara[8]だけを1にする
        PlayerPrefsUtility.SaveList<int>("select_chara", chara);    //charaをセーブする
    }
}
