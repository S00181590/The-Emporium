using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="ItemLibrary", menuName = "Storage/Items", order =1)]
public class ItemLibrary : ScriptableObject
{
    [SerializeField] List<Item> ItemStorage = new List<Item>();
}
