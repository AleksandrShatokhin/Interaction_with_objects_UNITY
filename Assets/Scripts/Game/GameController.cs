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

    [SerializeField] private GameObject pausePrefab;

    private bool isPause = false, isMouse = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetMouse();
    }

    public PlayerController GetPlayerController() => playerController;
    public MainUI GetMainUI() => mainui;
    public InventoryManager GetInventoryManager() => inventoryManager;

    public void OutputTextArmorOnScreen(float speed, int health, int experience) => mainui.OutputTextArmorOnScreen(speed, health, experience);

    public void GetMouse()
    {
        if (!isMouse)
        {
            MouseCursorOn();
            isMouse = true;
        }
        else
        {
            MouseCursorOff();
            isMouse = false;
        }
    }
    private void MouseCursorOn() => Cursor.visible = false;
    private void MouseCursorOff() => Cursor.visible = true;

    public void GetPauseMode()
    {
        if (!isPause)
        {
            isPause = true;
            GetMouse();
            CallPauseMode();
        }
        else
        {
            RevokePauseMode();
            GetMouse();
            isPause = false;
        }
    }

    private void CallPauseMode()
    {
        mainui.gameObject.SetActive(false);
        Instantiate(pausePrefab, pausePrefab.transform.position, pausePrefab.transform.rotation);
        Time.timeScale = 0.0f;
    }

    private void RevokePauseMode()
    {
        Time.timeScale = 1.0f;
        mainui.gameObject.SetActive(true);
        GameObject pause = GameObject.Find("PauseMode(Clone)");
        Destroy(pause);
    }
}