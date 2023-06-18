using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image cellIcon;
    [SerializeField] private Text cellCounter;

    [SerializeField] private PickableItem itemInCell;
    public PickableItem ItemInCell { get { return itemInCell; } }

    public void AddItemToEmptyCell(PickableItem item)
    {
        itemInCell = item;
        cellIcon.sprite = itemInCell.itemSO.Sprite;
        cellCounter.text = itemInCell.itemSO.Count.ToString();
    }

    public void AddItemToCurrentCell(PickableItem item)
    {
        int currentCount = int.Parse(cellCounter.text) + item.itemSO.Count;
        cellCounter.text = currentCount.ToString();
    }
}
