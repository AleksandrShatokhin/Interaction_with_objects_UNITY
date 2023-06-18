using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private List<GameObject> enemies;

    private void Start()
    {
        Cursor.visible = false;
        StartCoroutine(TurnOnEnemy());
    }

    private IEnumerator TurnOnEnemy()
    {
        yield return new WaitForSeconds(10.0f);
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            VisabilityOfTheInventory();
        }
    }

    private void VisabilityOfTheInventory()
    {
        if (inventory.activeInHierarchy == false)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
}
