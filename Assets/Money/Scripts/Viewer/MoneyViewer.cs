using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MoneyViewer : SingletonMonoBehaviour<MoneyViewer>
{
    [SerializeField] bool includeTempolaryMoney = true;
    [SerializeField] Text text;
    [SerializeField] float duration = 1f;
    [SerializeField] Ease ease = Ease.OutQuart;

    int beforeMoney;

    private void Start()
    {
        MoneyManager.Init();
        beforeMoney = MoneyManager.Money;
        text.text = MoneyManager.Money.ToString();
    }

    private void Update()
    {
        CheckFluct();
    }

    /// <summary>
    /// 所持金の変動を監視
    /// </summary>
    void CheckFluct()
    {
        if (includeTempolaryMoney)
        {
            if (MoneyManager.Money == beforeMoney) return;
            Fluct(MoneyManager.Money);
            beforeMoney = MoneyManager.Money;
        }
        else
        {
            if (MoneyManager.BeforeMoney == beforeMoney) return;
            Fluct(MoneyManager.BeforeMoney);
            beforeMoney = MoneyManager.BeforeMoney;
        }
    }

    /// <summary>
    /// 所持金の変動を文字に反映
    /// </summary>
    /// <param name="value">変動後の総額</param>
    void Fluct(int value)
    {
        float v = beforeMoney;
        beforeMoney = value;

        DOTween.To(() => v, num => v = num, value, duration).SetEase(ease)
        .OnUpdate(() =>
        {
            text.text = ((int)v).ToString();
        });
    }
}