using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkinPreviewer : MonoBehaviour
{
    [SerializeField] SkinManager manager;
    [SerializeField] Transform previewParent;
    [SerializeField] GameObject tryOnDisplay;

    private void Start()
    {
        manager.StartEvent += button => UpdatePreview(button);
        manager.SelectEvent += button => UpdatePreview(button);
    }
    /// <summary>
    /// プレビューを更新
    /// </summary>
    /// <param name="button"></param>
    private void UpdatePreview(SkinButton button)
    {
        if (previewParent.childCount > 0) Destroy(previewParent.GetChild(0).gameObject);
        Instantiate(button.Skin.Prefab, previewParent);

        if (tryOnDisplay) tryOnDisplay.SetActive(!button.Unlocked);
    }
}