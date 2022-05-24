using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInScene : MonoBehaviour
{
    [SerializeField] private ItemsData itemData;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameController.GetInstance().GetInventoryManager().SetValueInInventory(itemData.icon, itemData.quantity, itemData.value);
            Destroy(this.gameObject);
        }
    }
}
