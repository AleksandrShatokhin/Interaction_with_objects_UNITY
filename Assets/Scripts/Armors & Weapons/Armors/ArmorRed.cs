using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorRed : ArmorManager
{
    private Armor armor = new Armor();

    private void Start()
    {
        armor.SetCharacteristics(speed, health, experience);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.tag == "Player")
        {
            armor.TransferCharacteristicsToPlayer();
        }
    }
}
