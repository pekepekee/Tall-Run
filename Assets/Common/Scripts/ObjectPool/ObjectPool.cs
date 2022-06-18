using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ObjectPool : MonoBehaviour
{
    private PoolableMonoBehaviour original;
    private Stack<PoolableMonoBehaviour> pool = new Stack<PoolableMonoBehaviour>();

    /// <summary>
    /// オブジェクトプールするものをセット
    /// </summary>
    /// <param name="original">オブジェクトプールするもの</param>
    public void SetOriginal(PoolableMonoBehaviour original)
    {
        this.original = original;
    }

    /// <summary>
    /// プールから一つ取り出す
    /// </summary>
    /// <returns>オブジェクト</returns>
    public Component Create()
    {
        PoolableMonoBehaviour obj;
        if (pool.Count > 0)
        {
            obj = pool.Pop();
        }
        else
        {
            obj = Instantiate(original).GetComponent<PoolableMonoBehaviour>();
            obj.Pool = this;
        }
        obj.Init();
        return obj;
    }

    /// <summary>
    /// プールに戻す
    /// </summary>
    /// <param name="obj">オブジェクト</param>
    public void Release(PoolableMonoBehaviour obj)
    {
        obj.Sleep();
        pool.Push(obj);
    }

    /// <summary>
    /// プールの要素数を取得
    /// </summary>
    /// <returns>要素数</returns>
    public int GetPoolCount()
    {
        return pool.Count;
    }

    /// <summary>
    /// プールの要素を破棄
    /// </summary>
    /// <param name="count"破棄数</param>
    public void Destroy(int count)
    {
        for (int i = Mathf.Min(pool.Count, count) - 1; i >= 0; i--)
        {
            Destroy(pool.Pop().gameObject);
        }
    }
    /// <summary>
    /// 全てのプールの要素を破棄
    /// </summary>
    public void DestroyAll()
    {
        foreach (PoolableMonoBehaviour item in pool)
        {
            if (item == null) continue;
            Destroy(item.gameObject);
        }
        pool.Clear();
    }

    /// <summary>
    /// プールするオブジェクトをあらかじめ生成
    /// </summary>
    /// <param name="count">生成数</param>
    /// <param name="duration">生成時間</param>
    public async void Preload(int count, float duration)
    {
        if (!Mathf.Approximately(duration, 0f))
        {
            int interval = (int)(duration / count * 1000f);
            PreloadOnce();

            for (int i = count - 2; i >= 0; i--)
            {
                await Task.Delay(interval);
                PreloadOnce();
            }
        }
        else
        {
            for (int i = count - 1; i >= 0; i--) PreloadOnce();
        }

        void PreloadOnce()
        {
            PoolableMonoBehaviour obj = Instantiate(original).GetComponent<PoolableMonoBehaviour>();
            obj.Pool = this;
            Release(obj);
        }
    }
}