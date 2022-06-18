using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// インゲームで獲得したお金をアウトゲームの所持金に追加する
/// </summary>
public class CashManager : SingletonMonoBehaviour<CashManager>
{
    [SerializeField] PoolableMonoBehaviour originalCash;
    [SerializeField] Transform moneyViewAnchor;
    [SerializeField] float duration = 0.5f;

    private Camera mainCam;

    ObjectPool pool = new ObjectPool();

    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Init()
    {
        pool.SetOriginal(originalCash);
    }

    /// <summary>
    /// お金獲得
    /// </summary>
    /// <param name="value">金額</param>
    public void GetCash(int value)
    {
        MoneyManager.TemporaryMoney += value;
    }
    /// <summary>
    /// お金獲得
    /// </summary>
    /// <param name="position">獲得地点</param>
    public void GetCash(Vector3 position) => GetCash(1, position);
    /// <summary>
    /// お金獲得
    /// </summary>
    /// <param name="value">金額</param>
    /// <param name="position">座標</param>
    public void GetCash(int value, Vector3 position)
    {
        if (!mainCam) mainCam = Camera.main;
        GetCash2D(value, mainCam.WorldToScreenPoint(position));
    }

    /// <summary>
    /// お金獲得
    /// </summary>
    /// <param name="value">金額</param>
    /// <param name="screenPosition">スクリーン座標</param>
    public void GetCash2D(int value, Vector2 screenPosition)
    {
        SimplePoolableMonoBehaviour cash = pool.Create() as SimplePoolableMonoBehaviour;
        RectTransform rect = cash.transform as RectTransform;
        rect.SetParent(moneyViewAnchor);

        rect.position = screenPosition;
        rect.localScale = Vector3.one;

        rect.DOAnchorPos(Vector2.zero, duration);

        DOVirtual.DelayedCall(duration, () =>
        {
            MoneyManager.TemporaryMoney += value;
            cash.Pool.Release(cash);
        });
    }

    /// <summary>
    /// 大量のコインを一気に獲得
    /// </summary>
    /// <param name="value">総額</param>
    /// <param name="split">1コインの重み</param>
    /// <param name="screenCenterPosition">座標</param>
    /// <param name="range">生成範囲</param>
    /// <param name="save">保存</param>
    public void GetCashes(int value, int split, Vector3 position, Vector2 range, float delay, float delayRange, bool save)
    {
        if (!mainCam) mainCam = Camera.main;
        GetCashes2D(value, split, mainCam.WorldToScreenPoint(position), range, delay, delayRange, save);
    }

    /// <summary>
    /// 大量のコインを一気に獲得
    /// </summary>
    /// <param name="value">総額</param>
    /// <param name="split">1コインの重み</param>
    /// <param name="screenPosition">スクリーン座標</param>
    /// <param name="range">生成範囲</param>
    /// <param name="save">保存</param>
    public void GetCashes2D(int value, int split, Vector2 screenPosition, Vector2 range, float delay, float delayRange, bool save)
    {
        Vector2 pos;
        for (int v = value; v > 0; v -= split)
        {
            DOVirtual.DelayedCall(delay + Random.Range(-delayRange, delayRange), () =>
            {
                pos = screenPosition
                    + Vector2.right * Random.Range(-range.x, range.x)
                    + Vector2.up * Random.Range(-range.y, range.y);
                GetCash2D(0, pos);
            }).SetLink(gameObject);
        }

        DOVirtual.DelayedCall(delay, () =>
        {
            MoneyManager.TemporaryMoney += value;
            if (save) MoneyManager.ApplyAndSave();
        }).SetLink(gameObject);
    }

    /// <summary>
    /// お金消費
    /// </summary>
    /// <param name="value">金額</param>
    /// <param name="split">1コインの重み</param>
    /// <param name="position">座標</param>
    /// <param name="duration">持続時間</param>
    /// <param name="save">保存</param>
    public void LostCashes(int value, int split, Vector3 position, float duration, bool save)
    {
        if (!mainCam) mainCam = Camera.main;
        LostCashes2D(value, split, mainCam.WorldToScreenPoint(position), duration, save);
    }

    /// <summary>
    /// お金消費
    /// </summary>
    /// <param name="value">金額</param>
    /// <param name="split">1コインの重み</param>
    /// <param name="screenPosition">スクリーン座標</param>
    /// <param name="duration">持続時間</param>
    /// <param name="save">保存</param>
    public void LostCashes2D(int value, int split, Vector2 screenPosition, float duration, bool save)
    {
        MoneyManager.ForcedPay(value);
        if (save) MoneyManager.ApplyAndSave();

        float divided = 1f / Mathf.Max(1, value);

        for (int v = value; v > 0; v -= split)
        {
            DOVirtual.DelayedCall(duration * divided * v, () =>
            {
                SimplePoolableMonoBehaviour cash = pool.Create() as SimplePoolableMonoBehaviour;
                RectTransform rect = cash.transform as RectTransform;
                rect.SetParent(moneyViewAnchor);

                rect.position = Vector2.zero;
                rect.localScale = Vector3.one;

                rect.DOAnchorPos(moneyViewAnchor.InverseTransformPoint(screenPosition), duration).OnComplete(() => cash.Pool.Release(cash));
            }).SetLink(gameObject);
        }
    }
}