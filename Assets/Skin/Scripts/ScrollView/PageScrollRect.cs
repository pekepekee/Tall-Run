// 2016/01/21
// @okuhiiro
// uGUIのScroll Viewでページスクロール
// https://qiita.com/okuhiiro/items/0b356b18764faa734f1a

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public class PageScrollRect : ScrollRect
{
    const float
        TWEEN_DURATION_SECOND = 0.2f,
        SWIPE_SPEED_THRESHOLD = 5f;
    const Ease TWEEN_EASE = Ease.OutQuart;

    private float pageWidth;
    private int prevPageIndex = 0, pageIndexCount;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {
        // ページ数を取得
        pageIndexCount = content.childCount;
        // 1ページの幅を取得
        GridLayoutGroup grid = content.GetComponent<GridLayoutGroup>();
        pageWidth = grid.cellSize.x + grid.spacing.x;
    }

    /// <summary>
    /// ScrollViewから指を離したときに実行
    /// </summary>
    /// <param name="eventData">Contentの座標と移動量</param>
    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        StopMovement();
        MovePage(eventData);
    }

    /// <summary>
    /// 中央に近いページを中央に、滑らかに移動
    /// </summary>
    /// <param name="eventData">Contentの座標と移動量</param>
    private void MovePage(PointerEventData eventData)
    {
        int pageIndex = Mathf.RoundToInt(content.anchoredPosition.x / pageWidth);

        // スワイプ判定
        if (pageIndex == prevPageIndex && Mathf.Abs(eventData.delta.x) >= SWIPE_SPEED_THRESHOLD)
        {
            pageIndex += Mathf.RoundToInt(Mathf.Sign(eventData.delta.x));
        }

        content.DOAnchorPosX(pageIndex * pageWidth, TWEEN_DURATION_SECOND).SetEase(TWEEN_EASE);
        prevPageIndex = pageIndex;
    }
}