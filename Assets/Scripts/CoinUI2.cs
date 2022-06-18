using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI2 : MonoBehaviour
{
    float cointotal;
    public GameObject coin_object = null;
    // Start is called before the first frame update
    void Start()
    {
        cointotal = PlayerPrefs.GetFloat("coin", 0);
        Text coin_text = coin_object.GetComponent<Text>();
        coin_text.text = "totalcoin:" + cointotal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
