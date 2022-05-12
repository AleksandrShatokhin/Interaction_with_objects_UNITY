using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{

}

public class Armor
{
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
        PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();

        player.ResetArmor();
        player.PutOnArmor(speed, health, experience);
    }
}
