using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashFlucter : MonoBehaviour
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

    [SerializeField] int split = 1;
    [SerializeField] RectTransform centerTransform;
    [SerializeField] Vector2 range;
    [SerializeField] float delay, delayRange;

    private void Awake()
    {
        if (mode == Mode.OnAwake) Fluct(value);
        if (save) ApplyAndSave();
    }

    void OnEnable()
    {
        if (mode == Mode.OnEnable) Fluct(value);
        if (save) ApplyAndSave();
    }
    void OnDisable()
    {
        if (mode == Mode.OnDisable) Fluct(value);
        if (save) ApplyAndSave();
    }
    void OnDestroy()
    {
        if (mode == Mode.OnDestroy) Fluct(value);
        if (save) ApplyAndSave();
    }

    public void Fluct(int value)
    {
        if (value > 0)
        {
            CashManager.Instance.GetCashes(value, split, centerTransform.position, range, delay, delayRange, save);
        }
        else if (value < 0)
        {
            CashManager.Instance.LostCashes(value, split, centerTransform.position, delay, save);
        }
    }
    public void Fluct() => Fluct(value);

    public void ApplyAndSave()
    {
        MoneyManager.ApplyAndSave();
    }
}