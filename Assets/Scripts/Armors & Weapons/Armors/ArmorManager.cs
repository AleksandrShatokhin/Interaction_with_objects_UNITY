using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorManager : MonoBehaviour
{
    protected Armor armor;

    [SerializeField] protected float speed;
    [SerializeField] protected int health;
    [SerializeField] protected int experience;

    virtual protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            armor.TransferCharacteristicsToPlayer();
        }
    }
}
