using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollRectHorizontalContentPositionSetter : ContentPositonSetter
{
    [SerializeField] PageScrollRect scrollRect;

    float pageWidth;

    /// <summary>
    /// 初期化
    /// </summary>
    protected override void Start()
    {
        base.Start();
        // 1ページの幅を取得
        GridLayoutGroup grid = scrollRect.content.GetComponent<GridLayoutGroup>();
        pageWidth = grid.cellSize.x + grid.spacing.x;
    }

    /// <summary>
    /// 要素の配置順からページ数を計算し、そのページに移動する
    /// </summary>
    /// <param name="index">配置順</param>
    public override void SetSnap(int index)
    {
        if (index < maxPlacements)
        {
            scrollRect.content.anchoredPosition = new Vector2(0f, scrollRect.content.anchoredPosition.y);
            return;
        }
        scrollRect.content.anchoredPosition = new Vector2(-(index / maxPlacements) * pageWidth, scrollRect.content.anchoredPosition.y);
    }
}