using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ChildInventory
{
    icon = 0,
    counter = 1
}

public class InventoryManager : MonoBehaviour
{
    private bool isInventoryCalled = false;

    [SerializeField] protected Sprite iconDefault;
    [SerializeField] private List<GameObject> items;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void CallInventory()
    {
        if (!isInventoryCalled)
        {
            Time.timeScale = 0.0f;
            isInventoryCalled = true;
            this.gameObject.SetActive(true);
            GameController.GetInstance().GetMainUI().gameObject.SetActive(false);
        }
        else
        {
            Time.timeScale = 1.0f;
            isInventoryCalled = false;
            this.gameObject.SetActive(false);
            GameController.GetInstance().GetMainUI().gameObject.SetActive(true);
        }
    }

    public void SetValueInInventory(Sprite icon, int quantity)
    {
        items[0].transform.GetChild((int)ChildInventory.icon).GetComponent<Image>().sprite = icon;
        items[0].transform.GetChild((int)ChildInventory.counter).GetComponent<Text>().text = quantity.ToString();
    }
}
