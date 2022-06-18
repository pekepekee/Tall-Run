using System;
using UnityEngine;

public class MoneyManager
{
    const string MONEY_KEY = "Money";

    const int DEFAULT_VALUE = 10;

    private static int beforeMoney = 0, tempMoney = 0;
    private static bool initialized = false;

    /// <summary>
    /// 一時的なお金を含めない所持金
    /// </summary>
    public static int BeforeMoney
    {
        get
        {
            return beforeMoney;
        }
    }

    /// <summary>
    /// 所持金
    /// </summary>
    public static int Money
    {
        get
        {
            return beforeMoney + tempMoney;
        }
    }

    /// <summary>
    /// 一時的な金
    /// </summary>
    public static int TemporaryMoney
    {
        get
        {
            return tempMoney;
        }
        set
        {
            tempMoney = value;
        }
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public static void Init()
    {
        if (initialized) return;
        beforeMoney = SaveUtil.LoadInt(MONEY_KEY, DEFAULT_VALUE);
        initialized = true;
    }

    /// <summary>
    /// 支払えるか確認
    /// </summary>
    /// <param name="price">価格</param>
    /// <returns>支払える</returns>
    public static bool CheckPay(int price)
    {
        if (Money >= price) return true;
        else return false;
    }

    /// <summary>
    /// 一時的なお金から支払いを試みる
    /// </summary>
    /// <param name="price">価格</param>
    /// <returns>支払えたか</returns>
    public static bool TryPayFromTemporary(int price)
    {
        if (tempMoney >= price)
        {
            tempMoney -= price;
            return true;
        }
        return false;
    }

    /// <summary>
    /// 支払いを試みる
    /// </summary>
    /// <param name="price">価格</param>
    /// <returns>支払えたか</returns>
    public static bool TryPay(int price)
    {
        if (Money < price) return false;
        if (tempMoney >= price)
        {
            tempMoney -= price;
            return true;
        }
        beforeMoney += tempMoney;
        tempMoney = 0;
        beforeMoney -= price;
        return true;
    }

    /// <summary>
    /// 支払って保存を試みる
    /// </summary>
    /// <param name="price">価格</param>
    /// <returns>支払えたか</returns>
    public static bool TryPayAndSave(int price)
    {
        if (Money < price) return false;
        beforeMoney += tempMoney;
        tempMoney = 0;
        beforeMoney -= price;
        Save();
        return true;
    }

    /// <summary>
    /// 罰金を支払って保存（所持金が足りない場合、所持金は0になる）
    /// </summary>
    /// <param name="price">金額</param>
    /// <returns>全額支払えたか</returns>
    public static bool FinePayAndSave(int price)
    {
        if (Money < price)
        {
            beforeMoney = 0;
            ApplyAndSave();
            return false;
        }
        if (tempMoney >= price)
        {
            tempMoney -= price;
            return true;
        }
        beforeMoney += tempMoney;
        tempMoney = 0;
        beforeMoney -= price;
        Save();
        return true;
    }

    /// <summary>
    /// 支払って保存（所持金がマイナスになり得る）
    /// </summary>
    /// <param name="price">価格</param>
    /// <returns>所持金があるか</returns>
    public static bool ForcedPay(int price)
    {
        if (tempMoney >= price)
        {
            tempMoney -= price;
            return true;
        }
        beforeMoney += tempMoney;
        tempMoney = 0;
        beforeMoney -= price;
        Save();

        if (Money >= 0) return true;
        return false;
    }

    /// <summary>
    /// 一時的な金を足さないで保存
    /// </summary>
    public static void Save()
    {
        SaveUtil.SaveInt(MONEY_KEY, beforeMoney);
    }

    /// <summary>
    /// 一時的な金を所持金に足して保存
    /// </summary>
    public static void ApplyAndSave()
    {
        beforeMoney += tempMoney;
        tempMoney = 0;

        SaveUtil.SaveInt(MONEY_KEY, beforeMoney);
    }
}