using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMain : MonoBehaviour
{
    [SerializeField] private InventoryCell[] inventoryCells;

    private void Start()
    {
        inventoryCells = this.GetComponentsInChildren<InventoryCell>();
        this.gameObject.SetActive(false);
    }

    public void AddItemToInventory(PickableItem item)
    {
        foreach (InventoryCell cell in inventoryCells)
        {
            if (cell.ItemInCell == null)
            {
                cell.AddItemToEmptyCell(item);
                return;
            }

            if (cell.ItemInCell.itemSO.ItemType == item.itemSO.ItemType)
            {
                cell.AddItemToCurrentCell(item);
                return;
            }
        }
    }
}
