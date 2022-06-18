using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "ScriptableObjects/Create Skin")]
public class Skin : ScriptableObject
{
    [SerializeField] SkinID id;
    public SkinID ID { get { return id; } }

    [SerializeField] new string name;
    public string Name { get { return name; } }

    [SerializeField] public int price;
    public int Price { get { return price; } }

    [SerializeField] public Sprite sprite;
    public Sprite Sprite { get { return sprite; } }

    [SerializeField] public GameObject prefab;
    public GameObject Prefab { get { return prefab; } }
}