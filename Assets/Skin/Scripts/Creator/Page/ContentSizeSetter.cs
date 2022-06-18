using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Vector2 cellSize;
    [SerializeField] Vector2 spacing;
    [SerializeField] GridLayoutGroup pageLayout;

    // Start is called before the first frame update
    void Start()
    {
        pageLayout.cellSize = cellSize;
        pageLayout.spacing = spacing;

        switch (pageLayout.startCorner)
        {
            case GridLayoutGroup.Corner.UpperLeft:
                pageLayout.padding.left = (int)(spacing.x * 0.5f);
                pageLayout.padding.top = (int)(spacing.y * 0.5f);
                break;
            case GridLayoutGroup.Corner.UpperRight:
                pageLayout.padding.right = (int)(spacing.x * 0.5f);
                pageLayout.padding.top = (int)(spacing.y * 0.5f);
                break;
            case GridLayoutGroup.Corner.LowerLeft:
                pageLayout.padding.left = (int)(spacing.x * 0.5f);
                pageLayout.padding.bottom = (int)(spacing.y * 0.5f);
                break;
            case GridLayoutGroup.Corner.LowerRight:
                pageLayout.padding.right = (int)(spacing.x * 0.5f);
                pageLayout.padding.bottom = (int)(spacing.y * 0.5f);
                break;
        }
    }
}
