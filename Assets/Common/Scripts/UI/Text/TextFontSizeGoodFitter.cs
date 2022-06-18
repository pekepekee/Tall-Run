using UnityEngine;
using UnityEngine.UI;

public class TextFontSizeGoodFitter : MonoBehaviour
{
    const float CONTENT_RATE = 0.95f;

    [SerializeField] bool updateOnAwake = true, everyUpdate = true;
    [SerializeField] Text text;
    int startFontSize;
    Rect rect;
    float rateX, rateY;

    private void Start()
    {
        text.horizontalOverflow = HorizontalWrapMode.Overflow;
        startFontSize = text.fontSize;
        rect = text.rectTransform.rect;

        if (updateOnAwake) UpdateFontSize();
    }

    private void Update()
    {
        if (everyUpdate) UpdateFontSize();
    }

    /// <summary>
    /// フォントサイズを更新
    /// </summary>
    public void UpdateFontSize()
    {
        text.fontSize = startFontSize;
        rateX = text.preferredWidth / rect.width;
        rateY = text.preferredHeight / rect.height;

        if (rateX > rateY)
        {
            text.fontSize = (int)(startFontSize / rateX * CONTENT_RATE);
        }
        else
        {
            text.fontSize = (int)(startFontSize / rateY * CONTENT_RATE);
        }
    }

    private void OnValidate()
    {
        if (text == null) TryGetComponent<Text>(out text);
    }
}