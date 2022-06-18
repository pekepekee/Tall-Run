using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCashesTemporaryMoney : MonoBehaviour
{
    [SerializeField] bool playOnAwake, save;
    [SerializeField] int split = 1;
    [SerializeField] RectTransform centerTransform;
    [SerializeField] Vector2 range;
    [SerializeField] float delay, delayRange;

    private void Start()
    {
        if (playOnAwake) GetCashesAndSave();
    }
    public void GetCashesAndSave()
    {
        int value = MoneyManager.TemporaryMoney;
        MoneyManager.TemporaryMoney = 0;
        CashManager.Instance.GetCashes(value, split, centerTransform.position, range, delay, delayRange, save);
    }
}