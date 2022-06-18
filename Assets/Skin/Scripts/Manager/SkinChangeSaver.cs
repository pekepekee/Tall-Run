using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChangeSaver : MonoBehaviour
{
    [SerializeField] SkinManager manager;

    void Start()
    {
        manager.SelectEvent += Manager_SelectEvent;
    }

    private void Manager_SelectEvent(SkinButton button)
    {
        if (button.Unlocked) SaveUtil.SaveInt(manager.ID, (int)button.Skin.ID);
    }
}