using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyAutoSaver : MonoBehaviour
{
    [SerializeField] float waitSecond = 5f;
    [SerializeField] int thresholdValue = 100;

    bool fluct;
    float waitCount;
    int beforeMoney;

    void Start()
    {
        MoneyManager.Init();
    }

    void Update()
    {
        if (MoneyManager.Money != beforeMoney)
        {
            fluct = true;
            waitCount = waitSecond;

            if (Mathf.Abs(beforeMoney - MoneyManager.Money) >= thresholdValue) ApplyAndSave();
        }
        else if (fluct)
        {
            waitCount -= Time.deltaTime;
            if (waitCount <= 0f) MoneyManager.ApplyAndSave();
        }
    }

    void ApplyAndSave()
    {
        fluct = false;
        MoneyManager.ApplyAndSave();
        beforeMoney = MoneyManager.Money;
    }
}