using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private MainUI mainui;

    private SaveData saveData = new SaveData();

    private int bulletsInClipHandgun, bulletsInPouchHandgun;
    private int bulletsInClipMachinegun, bulletsInPouchMachinegun;

    private void Awake()
    {
        instance = this;
    }

    public PlayerController GetPlayerController() => playerController;
    public MainUI GetMainUI() => mainui;

    public void OutputTextArmorOnScreen(float speed, int health, int experience) => mainui.OutputTextArmorOnScreen(speed, health, experience);

    public void SetData(string tagWeapon, int bulletsInClip, int bulletsInPouch)
    {
        saveData.SetData(tagWeapon, bulletsInClip, bulletsInPouch);
    }

    public int GetBulletsInClipHandgun() => saveData.GetBulletsInClipHandGun();
    public int GetBulletsInPouchHandgun() => saveData.GetBulletsInPouchHandGun();
    public int GetBulletsInClipMachinegun() => saveData.GetBulletsInClipMachineGun();
    public int GetBulletsInPouchMachinegun() => saveData.GetBulletsInPouchMachineGun();
}