using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum NumberWeapon
{
    machinegun = 0,
    handgun = 1
}

public class Utility : MonoBehaviour
{

}

public class Armor
{
    private PlayerController playerController;

    private float speed;
    private int health;
    private int experience;

    public void SetCharacteristics(float speed, int health, int experience)
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

    private GameObject currentWeapon;

    public void SetCurrentWeapon(GameObject currentWeapon)
    {
        this.currentWeapon = currentWeapon;
    }

    public void PlayerTakesWeapon()
    {
        playerController = GameController.GetInstance().GetPlayerController();

        playerController.TakeWeapon(currentWeapon);
    }
}
