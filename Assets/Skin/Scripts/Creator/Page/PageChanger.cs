using UnityEngine;
using UnityEngine.UI;

public class PageChanger : MonoBehaviour
{
    [SerializeField] PageScrollRect scrollRect;

    float pageWidth;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init()
    {
        // 1ページの幅を取得
        GridLayoutGroup grid = scrollRect.content.GetComponent<GridLayoutGroup>();
        pageWidth = grid.cellSize.x + grid.spacing.x;
    }

    /// <summary>
    /// 一瞬でページを移動
    /// </summary>
    /// <param name="page">ページ番号（0,-1,-2 と続く）</param>
    public void ChangePage(int page)
    {
        scrollRect.content.anchoredPosition = new Vector2(page * pageWidth, scrollRect.content.anchoredPosition.y);
    }
}