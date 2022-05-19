using UnityEngine;

enum NumberWeapon
{
    machinegun = 0,
    handgun = 1
}

public class Utility
{

}

public class Armor
{
    private PlayerController playerController;

    private float speed;
    private int health;
    private int experience;

    public Armor(float speed, int health, int experience)
    {
        this.speed = speed;
        this.health = health;
        this.experience = experience;
    }

    public void TransferCharacteristicsToPlayer()
    {
        playerController = GameController.GetInstance().GetPlayerController();
        playerController.ResetArmor();
        playerController.PutOnArmor(speed, health, experience);
    }
}

public class Weapon
{
    private PlayerController playerController;
    private MainUI mainui;
    private GameObject currentWeapon;
    private int quantityBulletsInClip;
    private int quantityBulletsInPouch;
    private int differenceBullets;
    private bool isCanShot;

    public Weapon(GameObject currentWeapon)
    {
        this.currentWeapon = currentWeapon;
    }

    public Weapon(int quantityBulletsInClip, int quantityBulletsInPouch)
    {
        this.quantityBulletsInClip = quantityBulletsInClip;
        this.quantityBulletsInPouch = quantityBulletsInPouch;

        this.differenceBullets = quantityBulletsInClip;

        if (quantityBulletsInClip <= 0 && quantityBulletsInPouch <= 0)
        {
            isCanShot = false;
        }
        else
        {
            isCanShot = true;
        }
    }

    public void ChangeBullets(int addBullet)
    {
        quantityBulletsInClip += addBullet;

        if (quantityBulletsInPouch <= 0 && quantityBulletsInClip <= 0)
        {
            isCanShot = false;
        }
        else
        {
            if (quantityBulletsInClip <= 0)
            {
                quantityBulletsInPouch -= differenceBullets;
                quantityBulletsInClip += differenceBullets;
            }
        }

        OutputBulletsTextOnScreen();
    }

    public bool IsCanShot() => isCanShot;
    public int GetQuantityBulletsInClip() => quantityBulletsInClip;
    public int GetQuantityBulletsInPouch() => quantityBulletsInPouch;

    public void OutputBulletsTextOnScreen()
    {
        mainui = GameController.GetInstance().GetMainUI();
        mainui.OutputTextBulletsOnScreen(quantityBulletsInClip, quantityBulletsInPouch);
    }

    public void PlayerTakesWeapon()
    {
        playerController = GameController.GetInstance().GetPlayerController();
        playerController.TakeWeapon(currentWeapon);
    }
}

public class SaveDataWeapon
{
    public void SetData(string tagWeapon, int bulletsInClip, int bulletsInPouch)
    {
        if (tagWeapon == "HandGun")
        {
            PlayerPrefs.SetInt("BulletsInClipHandGun", bulletsInClip);
            PlayerPrefs.SetInt("BulletsInPouchHandGun", bulletsInPouch);
        }

        if (tagWeapon == "MachineGun")
        {
            PlayerPrefs.SetInt("BulletsInClipMachineGun", bulletsInClip);
            PlayerPrefs.SetInt("BulletsInPouchMachineGun", bulletsInPouch);
        }
    }

    public int GetBulletsInClipHandGun() => PlayerPrefs.GetInt("BulletsInClipHandGun");
    public int GetBulletsInPouchHandGun() => PlayerPrefs.GetInt("BulletsInPouchHandGun");

    public int GetBulletsInClipMachineGun() => PlayerPrefs.GetInt("BulletsInClipMachineGun");
    public int GetBulletsInPouchMachineGun() => PlayerPrefs.GetInt("BulletsInPouchMachineGun");
}

public interface IStateCellInventory
{
    void Enter();
    void Exit();
}
