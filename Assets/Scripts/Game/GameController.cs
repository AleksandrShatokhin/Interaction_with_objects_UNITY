using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private MainUI mainui;
    [SerializeField] private InventoryManager inventoryManager;

    private void Awake()
    {
        instance = this;
    }

    public PlayerController GetPlayerController() => playerController;
    public MainUI GetMainUI() => mainui;
    public InventoryManager GetInventoryManager() => inventoryManager;

    public void OutputTextArmorOnScreen(float speed, int health, int experience) => mainui.OutputTextArmorOnScreen(speed, health, experience);
}