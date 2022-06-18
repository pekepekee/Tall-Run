using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 選択中のスキンを目立たせる
/// </summary>
public class SkinButtonHighlighter : MonoBehaviour
{
    [SerializeField] SkinManager manager;
    [SerializeField] RectTransform rectTransform;

    private void Start()
    {
        manager.StartEvent += b => UpdateTranform(b);
        manager.SelectEvent += b => UpdateTranform(b);
    }

    /// <summary>
    /// 位置変更
    /// </summary>
    /// <param name="button">ボタン</param>
    private void UpdateTranform(SkinButton button)
    {
        if (!button.Unlocked) return;
        rectTransform.SetParent(button.RectTransform);
        rectTransform.anchoredPosition = Vector2.zero;
    }
}