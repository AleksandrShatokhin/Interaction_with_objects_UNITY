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

    public Weapon(GameObject currentWeapon)
    {
        this.currentWeapon = currentWeapon;
    }

    public Weapon(int quantityBulletsInClip, int quantityBulletsInPouch)
    {
        this.quantityBulletsInClip = quantityBulletsInClip;
        this.quantityBulletsInPouch = quantityBulletsInPouch;
    }

    public Weapon(GameObject currentWeapon, int quantityBulletsInClip, int quantityBulletsInPouch)
    {
        this.currentWeapon = currentWeapon;
        this.quantityBulletsInClip = quantityBulletsInClip;
        this.quantityBulletsInPouch = quantityBulletsInPouch;
    }

    public void ChangeBullets(int addBullet)
    {
        quantityBulletsInClip += addBullet;
        OutputBulletsTextOnScreen();
    }

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

class SaveData
{
    int bulletsInClipHandGun, bulletsInPouchHandGun;
    int bulletsInClipMachineGun, bulletsInPouchMachineGun;

    public void SetData(string tagWeapon, int bulletsInClip, int bulletsInPouch)
    {
        if (tagWeapon == "HandGun")
        {
            bulletsInClipHandGun = bulletsInClip;
            bulletsInPouchHandGun = bulletsInPouch;
        }

        if (tagWeapon == "MachineGun")
        {
            bulletsInClipMachineGun = bulletsInClip;
            bulletsInPouchMachineGun = bulletsInPouch;
        }
    }

    public int GetBulletsInClipHandGun() => bulletsInClipHandGun;
    public int GetBulletsInPouchHandGun() => bulletsInPouchHandGun;

    public int GetBulletsInClipMachineGun() => bulletsInClipMachineGun;
    public int GetBulletsInPouchMachineGun() => bulletsInPouchMachineGun;
}
