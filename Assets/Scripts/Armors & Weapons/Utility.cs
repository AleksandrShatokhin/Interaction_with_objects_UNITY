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
