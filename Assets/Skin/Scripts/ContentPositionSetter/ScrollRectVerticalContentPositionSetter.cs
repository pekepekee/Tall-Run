using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectVerticalContentPositionSetter : ContentPositonSetter
{
    [SerializeField] PageScrollRect scrollRect;

    float pageHeight;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Start()
    {
        base.Start();
        // 1ページの幅を取得
        GridLayoutGroup grid = scrollRect.content.GetComponent<GridLayoutGroup>();
        pageHeight = grid.cellSize.y + grid.spacing.y;
    }

    /// <summary>
    /// 要素の配置順からページ数を計算し、そのページに移動する
    /// </summary>
    /// <param name="index">配置順</param>
    public override void SetSnap(int index)
    {
        if (index < maxPlacements)
        {
            scrollRect.content.anchoredPosition = new Vector2(scrollRect.content.anchoredPosition.x, 0f);
            return;
        }
        scrollRect.content.anchoredPosition = new Vector2(scrollRect.content.anchoredPosition.x, -(index / maxPlacements) * pageHeight);
    }
}