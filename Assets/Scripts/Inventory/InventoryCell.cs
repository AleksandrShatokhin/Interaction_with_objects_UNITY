using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    [SerializeField] private Image cellIcon;
    [SerializeField] private Text cellCounter;

    [SerializeField] private PickableItem itemInCell;
    public PickableItem GetItemInSell() => itemInCell;

    public void SetItemToEmptyCell(PickableItem item)
    {
        itemInCell = item;
        cellIcon.sprite = itemInCell.itemSO.Sprite;
        cellCounter.text = itemInCell.itemSO.Count.ToString();
    }

    public void SetItemToCurrentCell(PickableItem item)
    {
        int currentCount = int.Parse(cellCounter.text) + item.itemSO.Count;
        cellCounter.text = currentCount.ToString();
    }
}
