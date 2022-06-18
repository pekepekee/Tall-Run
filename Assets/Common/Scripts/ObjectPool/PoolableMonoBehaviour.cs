using UnityEngine;


public abstract class PoolableMonoBehaviour : MonoBehaviour
{
    public ObjectPool Pool { get; set; }
    public abstract void Init();
    public abstract void Sleep();
}