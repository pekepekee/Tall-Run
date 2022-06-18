using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinButtonCreatorOfScrollRect : SkinButtonCreator
{
    [Header("Create Page and Button")]
    [SerializeField] PageScrollRect scrollRect;
    [SerializeField] GridLayoutGroup page;

    [Header ("Page Setting")]
    [SerializeField] protected Vector2Int cellPlacement = new Vector2Int(3, 2);
    [SerializeField] protected Vector2Int pageSize = new Vector2Int(1000, 500);
    [SerializeField] protected Vector2Int cellSize = new Vector2Int(230, 230);
    [SerializeField] protected Vector2Int padding = new Vector2Int(10, 10);
    [SerializeField] protected Vector2Int spacing = new Vector2Int(100, 0);

    public int CellCount { get { return cellPlacement.x * cellPlacement.y; } }

    /// <summary>
    /// スキンデータのリストからボタンとページを生成
    /// </summary>
    /// <param name="skins">スキンデータ</param>
    /// <param name="IDs">解除済リスト</param>
    /// <param name="buttons">ボタンのリスト</param>
    /// <param name="selectEvent">選択時のイベント</param>
    public override void Create(Skins skins, List<SkinID> IDs, out List<SkinButton> buttons, Action<SkinButton> selectEvent)
    {
        List<SkinID> skinIDs = new List<SkinID>(IDs);
        buttons = new List<SkinButton>();
        SkinButton button;
        int placementsCount = 0;
        GridLayoutGroup page = null;

        content.cellSize = (cellSize + padding * 2) * cellPlacement;
        content.padding.left = (int)(pageSize.x - content.cellSize.x) / 2;
        content.padding.right = content.padding.left;
        content.spacing = spacing;

        contentRectTransform = content.transform as RectTransform;

        for (int i = 0; i < skins.Data.Count; i++)
        {
            // 新しいページを生成
            if (placementsCount == 0)
            {
                placementsCount += CellCount;
                page = Instantiate(this.page, contentRectTransform);
                SettingContent(page, cellSize, padding);
            }
            placementsCount--;

            // ボタンを生成
            button = CreateButton(
                    skins.Data[i],
                    selectEvent,
                    i,
                    CheckID(skins.Data[i].ID, skinIDs)
                );
            buttons.Add(button);

            button.transform.SetParent(page.transform as RectTransform);
        }

        scrollRect.Init();
    }

    /// <summary>
    /// ボタンを入れるContentのLayoutGroupに値を適応
    /// </summary>
    protected virtual void SettingContent(GridLayoutGroup content, Vector2 cellSize, Vector2Int padding)
    {

        content.cellSize = cellSize;
        switch (content.startCorner)
        {
            case GridLayoutGroup.Corner.UpperLeft:
                content.padding.left = padding.x;
                content.padding.top = padding.y;
                break;
            case GridLayoutGroup.Corner.UpperRight:
                content.padding.right = padding.x;
                content.padding.top = padding.y;
                break;
            case GridLayoutGroup.Corner.LowerLeft:
                content.padding.left = padding.x;
                content.padding.bottom = padding.y;
                break;
            case GridLayoutGroup.Corner.LowerRight:
                content.padding.right = padding.x;
                content.padding.bottom = padding.y;
                break;
        }
        content.spacing = padding * 2;
    }
}