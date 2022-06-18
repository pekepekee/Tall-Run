using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class SkinButton : MonoBehaviour
{
    public RectTransform RectTransform {  get { return rectTransform; } }
    [SerializeField] RectTransform rectTransform;

    [SerializeField] Button button;
    [SerializeField] Image image, lockImage;
    [SerializeField] Text text;
    [SerializeField] int price;

    public Skin Skin { get; private set; }
    public int Index { get; private set; }
    public bool Unlocked { get; private set; }

    /// <summary>
    /// 設定
    /// </summary>
    public void Init(Skin skinData, Action<SkinButton> e, int index)
    {
        Skin = skinData;
        Index = index;
        if (image) image.sprite = skinData.sprite;
        if (text) text.text = skinData.name;

        button.onClick.AddListener(() =>
        {
            e.Invoke(this);
        });
    }

    /// <summary>
    /// 解除
    /// </summary>
    public void Unlock()
    {
        Unlocked = true;
        button.interactable = true;
        if (lockImage) lockImage.enabled = false;
    }

    /// <summary>
    /// 表示順を更新
    /// </summary>
    /// <param name="i">新しい表示順</param>
    public void UpdateIndex(int i)
    {
        Index = i;
    }
}