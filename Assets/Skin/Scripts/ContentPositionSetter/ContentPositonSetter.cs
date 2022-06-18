using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ContentPositonSetter : MonoBehaviour
{
    [SerializeField] SkinManager manager;
    [SerializeField] SkinButtonCreatorOfScrollRect creator;

    protected int maxPlacements { get; private set; } = 1;

    protected virtual void Start()
    {
        maxPlacements = creator.CellCount;
        manager.SelectEvent += button => SetSnap(button.Index);
    }

    /// <summary>
    /// 要素の配置順からページ数を計算し、そのページに移動する
    /// </summary>
    /// <param name="index">配置順</param>
    public abstract void SetSnap(int index);
}