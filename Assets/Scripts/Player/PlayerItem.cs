using UnityEngine;

public class PlayerItem : MonoBehaviour, IPickableItem
{
    private InventoryMain inventory;

    private void Start()
    {
        inventory = GetComponent<PlayerController>().GetInventoryController();
    }

    void IPickableItem.PickableItem(PickableItem item)
    {
        inventory.AddItemToInventory(item);
    }
}
