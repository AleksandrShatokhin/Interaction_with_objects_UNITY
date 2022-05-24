using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private bool isInventoryCalled = false;

    [SerializeField] protected Sprite iconDefault;
    [SerializeField] private List<GameObject> items;

    private void Start()
    {
        StartCoroutine(ActiveInventoryOn());
    }

    IEnumerator ActiveInventoryOn()
    {
        yield return new WaitForSeconds(0.01f);
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

    public void SetValueInInventory(Sprite icon, int quantity, int value)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].GetComponent<CellController>().GetValue() == value)
            {
                items[i].GetComponent<CellController>().AddItemToCurrent(quantity);
                break;
            }
            else
            {
                if (items[i].GetComponent<CellController>().GetState() == (int)StateCell.StateDefault)
                {
                    items[i].GetComponent<CellController>().StateHaveItem(icon, quantity, value);
                    break;
                }
                
            }
        }
    }
}
