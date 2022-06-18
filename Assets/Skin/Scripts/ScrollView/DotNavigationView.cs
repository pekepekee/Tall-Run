using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DotNavigationView : MonoBehaviour
{
    [SerializeField]
    Image enableImage;

    public void View(bool enable)
    {
        enableImage.enabled = enable;
    }
}