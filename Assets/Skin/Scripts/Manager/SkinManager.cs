using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using DG.Tweening;

[DefaultExecutionOrder(100)]
public class SkinManager : MonoBehaviour
{
    [SerializeField] bool activateOnAwake = true;

    public SaveID ID { get { return id; } }
    public SaveID FlagID { get { return flagId; } }
    [SerializeField] SaveID id, flagId;
    [SerializeField] Skins skins;

    [SerializeField] List<SkinID> defaultUnlocks;

    [SerializeField] SkinButtonCreator creator;

    [NonSerialized] public List<SkinButton> Buttons = new List<SkinButton>();
    [NonSerialized] public List<SkinID> Unlocks;

    public event Action<SkinButton> StartEvent, SelectEvent;

    private void Start()
    {
        // 解除したスキン番号群を読み込み
        Unlocks = SaveUtil<SkinID>.LoadList(flagId, defaultUnlocks);

        // 生成
        creator.Create(skins, Unlocks, out Buttons, SelectEvent);

        // 現在のスキンに変更
        SkinID myID = (SkinID)SaveUtil.LoadInt(id, (int)defaultUnlocks[0]);
        StartEvent.Invoke(Buttons.FirstOrDefault(b => b.Skin.ID == myID));

        gameObject.SetActive(activateOnAwake);
    }

    /// <summary>
    /// ボタンを選択
    /// </summary>
    /// <param name="button">ボタン</param>
    public void Select(SkinButton button)
    {
        SelectEvent.Invoke(button);
    }
}