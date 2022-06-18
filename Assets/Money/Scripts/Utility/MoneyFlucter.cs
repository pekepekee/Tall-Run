using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyFlucter : MonoBehaviour
{
    public enum Mode
    {
        None,
        OnAwake,
        OnEnable,
        OnDisable,
        OnDestroy
    }
    [SerializeField] bool save;
    [SerializeField] Mode mode;
    [SerializeField] int value;

    private void Awake()
    {
        if (mode == Mode.OnAwake) Fluct(value);
        if (save) Save();
    }

    void OnEnable()
    {
        if (mode == Mode.OnEnable) Fluct(value);
        if (save) Save();
    }
    void OnDisable()
    {
        if (mode == Mode.OnDisable) Fluct(value);
        if (save) Save();
    }
    void OnDestroy()
    {
        if (mode == Mode.OnDestroy) Fluct(value);
        if (save) Save();
    }

    public void Fluct(int value)
    {
        MoneyManager.TemporaryMoney += value;
        if (save) Save();
    }
    public void Fluct() => Fluct(value);

    public void Save()
    {
        MoneyManager.ApplyAndSave();
    }
}