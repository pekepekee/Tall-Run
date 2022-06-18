using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class SkinUnlocker : MonoBehaviour
{
    [SerializeField] SkinManager manager;

    SkinButton button;

    void Start()
    {
        manager.SelectEvent += button => this.button = button;
    }

    /// <summary>
    /// ランダムに一つ解除
    /// </summary>
    public bool UnlockRandom()
    {
        // 未解除のスキンが無ければfalseを返す
        IEnumerable<SkinButton> tempButtons = manager.Buttons.Where(b => !b.Unlocked);
        if (!tempButtons.Any()) return false;

        UnlockProcess(
            // ランダムに一つ選択
            tempButtons.OrderBy(i => Guid.NewGuid()).FirstOrDefault()
            );
        return true;
    }
    public void _UnlockRandom() => UnlockRandom();

    /// <summary>
    /// 最後に選択したスキンを解除
    /// </summary>
    /// <returns>既に解除されていたらfalseを返す</returns>
    public bool UnlockSelectButton()
    {
        if (button.Unlocked) return false;
        UnlockProcess(button);
        return Unlock(button);
    }
    public void _UnlockSelectButton() => UnlockSelectButton();

    /// <summary>
    /// 指定のスキンを解除
    /// </summary>
    /// <param name="number">番号</param>
    /// <returns>既に解除されていたらfalseを返す</returns>
    public bool Unlock(SkinButton button)
    {
        if (button.Unlocked) return false;
        UnlockProcess(button);
        return true;
    }
    public void _Unlock(SkinButton button) => Unlock(button);

    /// <summary>
    /// 解除手続き
    /// </summary>
    /// <param name="button">ボタン</param>
    private void UnlockProcess(SkinButton button)
    {
        button.Unlock();

        manager.Unlocks.Add(button.Skin.ID);
        SaveUtil<SkinID>.SaveList(manager.FlagID, manager.Unlocks);

        SaveUtil.SaveInt(manager.ID, (int)button.Skin.ID);
        manager.Select(button);
    }
}
