using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Items Data")]
public class ItemsData : ScriptableObject
{
    public Sprite icon;
    public int quantity;
    public int value;
}
