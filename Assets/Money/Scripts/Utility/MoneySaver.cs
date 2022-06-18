using UnityEngine;

public class MoneySaver : MonoBehaviour
{
    [SerializeField]
    bool saveOnAwake = true;
    void Awake()
    {
        if (saveOnAwake) Save();
    }

    public void Save()
    {
        MoneyManager.ApplyAndSave();
    }
}