using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class SkinButtonCreator : MonoBehaviour
{
    [SerializeField] protected GridLayoutGroup content;
    protected RectTransform contentRectTransform;

    [SerializeField] protected SkinButton button;

    /// <summary>
    /// スキンデータのリストからボタンとページを生成
    /// </summary>
    /// <param name="skins">スキンデータ</param>
    /// <param name="IDs">解除済リスト</param>
    /// <param name="buttons">ボタンのリスト</param>
    /// <param name="@event">イベント</param>
    /// <param name="maxPlacementsCount">最大表示数</param>
    public virtual void Create(Skins skins, List<SkinID> IDs, out List<SkinButton> buttons, Action<SkinButton> selectEvent)
    {
        List<SkinID> skinIDs = new List<SkinID>(IDs);
        buttons = new List<SkinButton>();

        contentRectTransform = content.transform as RectTransform;

        for (int i = 0; i < skins.Data.Count; i++)
        {
            buttons.Add(
                CreateButton(
                    skins.Data[i],
                    selectEvent,
                    i,
                    CheckID(skins.Data[i].ID, skinIDs)
                )
            );
        }
    }

    /// <summary>
    /// ボタン生成
    /// </summary>
    /// <param name="skin">スキンデータ</param>
    /// <param name="selectEvent">選択イベント</param>
    /// <param name="index">表示順</param>
    /// <param name="unlocked">解除済か</param>
    /// <returns>ボタン</returns>
    protected SkinButton CreateButton(Skin skin, Action<SkinButton> selectEvent, int index, bool unlocked)
    {
        SkinButton btn = Instantiate(button, contentRectTransform);
        btn.Init(skin, selectEvent, index);
        if (unlocked) btn.Unlock();
        return btn;
    }

    /// <summary>
    /// リスト内にidと一致する要素があれば削除
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="IDs">リスト</param>
    /// <returns>一致するものがあったか</returns>
    protected bool CheckID(SkinID id, List<SkinID> IDs)
    {
        for (int i = 0; i < IDs.Count; i++)
        {
            if (id == IDs[i])
            {
                IDs.RemoveAt(i);
                return true;
            }
        }
        return false;
    }
}