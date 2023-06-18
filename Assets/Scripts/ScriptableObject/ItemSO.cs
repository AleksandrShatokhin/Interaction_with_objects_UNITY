using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObjects/ItemSO", order = 2)]
public class ItemSO : ScriptableObject
{
    public ListItemType ItemType;
    public Sprite Sprite;
    public int Count;
}

public enum ListItemType
{
    Apple,
    Coin,
    Booster
}