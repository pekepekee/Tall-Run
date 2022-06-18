using UnityEngine;

public class GetCashTest : MonoBehaviour
{
    void Update()
    {
        // 移動
        transform.position += Vector3.right * Time.deltaTime * 0.75f;

        // コインでお金を獲得
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CashManager.Instance.GetCash(50, transform.position);
        }

        // 数値でお金を獲得
        if (Input.GetKeyDown(KeyCode.Return))
        {
            MoneyManager.TemporaryMoney += 50;
        }

        // 保存
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoneyManager.ApplyAndSave();
        }
    }
}