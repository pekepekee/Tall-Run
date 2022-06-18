using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MoneyEditorController : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("Tools/Money/Plus 200")]
    static void Plus()
    {
        MoneyManager.TemporaryMoney += 200;
        MoneyManager.ApplyAndSave();
    }

    [MenuItem("Tools/Money/Minus 50")]
    static void Minus()
    {
        MoneyManager.TryPay(50);
    }
#endif
}