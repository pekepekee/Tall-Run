using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Goal2 : MonoBehaviour
{
#pragma warning disable 0649
    // Start is called before the first frame update
    [SerializeField] BoxCollider collider;
    [SerializeField]public int FIELD_SIZE_Y = 3;    //ゴールの高さ
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
                 for (int i = FIELD_SIZE_Y; i > 0; i--)
                {
                    if (Pmove.height > i - 1 && i >= Pmove.height)
                    {
                        Pmove.coin_get *= i + 1;    //コインをi+1倍する
                        break;
                    }
                }
            PlayerPrefs.SetFloat("coin", manager.coin_total + Pmove.coin_get);
            PlayerPrefs.Save();
            SceneManager.LoadScene("ClearScene");
            collider.enabled = false;
        }
    }
}

