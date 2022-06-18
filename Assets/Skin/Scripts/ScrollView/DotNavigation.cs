using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotNavigation : MonoBehaviour
{
    [SerializeField] SkinManager manager;

    [SerializeField] ScrollRect scrollRect;
    [SerializeField] GridLayoutGroup contentGrid;
    RectTransform contentTransform;
    [SerializeField] GridLayoutGroup dotGrid;
    RectTransform dotTransform;
    [SerializeField] DotNavigationView dot;

    private float pageWidth;
    private int pageIndexCount, prevPageIndex = 0;
    List<DotNavigationView> dots = new List<DotNavigationView>();

    private void Start()
    {
        scrollRect.onValueChanged.AddListener(_ => UpdateView());
        manager.StartEvent += b => Create();
    }

    /// <summary>
    /// 生成
    /// </summary>
    public void Create()
    {
        contentTransform = contentGrid.GetComponent<RectTransform>();
        dotTransform = dotGrid.GetComponent<RectTransform>();

        // ドットの削除
        if (dotTransform && dotTransform.childCount >= 1)
        {
            for (int i = dotTransform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(dotTransform.GetChild(i).gameObject);
            }
        }

        // ページ数を取得
        pageIndexCount = contentTransform.childCount;
        // ページがなければ終了
        if (pageIndexCount == 0) return;

        // 1ページの幅を取得
        pageWidth = contentGrid.cellSize.x + contentGrid.spacing.x;

        // ドット生成
        for (int i = 0; i < pageIndexCount; i++)
        {
            dots.Add(Instantiate(dot, dotTransform));
        }

        // 1ページ目を有効にする
        dots[0].View(true);
    }

    /// <summary>
    /// 表示を更新
    /// </summary>
    public void UpdateView()
    {
        int pageIndex = Mathf.Clamp(Mathf.RoundToInt(-contentTransform.anchoredPosition.x / pageWidth), 0, dots.Count - 1);

        if (pageIndex == prevPageIndex) return;

        dots[prevPageIndex].View(false);
        dots[pageIndex].View(true);

        prevPageIndex = pageIndex;
    }
}