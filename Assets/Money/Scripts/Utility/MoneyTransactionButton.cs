using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 所持金によって押せるボタン
/// </summary>
public class MoneyTransactionButton : MonoBehaviour
{
    [SerializeField] Button button;
    [SerializeField] int price;

    void Update()
    {
        button.interactable = MoneyManager.CheckPay(price);
    }

    /// <summary>
    /// 価格変更
    /// </summary>
    /// <param name="price">価格</param>
    public void ChangePrice(int price)
    {
        this.price = price;
    }

    /// <summary>
    /// 支払う
    /// </summary>
    public void Pay()
    {
        MoneyManager.ForcedPay(price);
    }

    private void OnValidate()
    {
        if (!button)
        {
            TryGetComponent(out Button b);
            button = b;
        }
    }
}