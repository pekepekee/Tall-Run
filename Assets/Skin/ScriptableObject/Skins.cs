using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skins", menuName = "ScriptableObjects/Create Skins")]
public class Skins : ScriptableObject
{
    [SerializeField] List<Skin> data;
    public List<Skin> Data { get { return data; } }
}