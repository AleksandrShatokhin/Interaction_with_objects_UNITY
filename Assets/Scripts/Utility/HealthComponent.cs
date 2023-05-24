using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IHealthable
{
    [SerializeField] private int health;
    [SerializeField] private int armor;

    void IHealthable.TakeDamage(int damage)
    {
        Debug.Log("Contact");

        int currentDamage = (damage - armor / 10);

        if (currentDamage < 0)
        {
            return;
        }

        health -= currentDamage;

        if (health <= 0)
        {
            this.GetComponent<IDeathable>().Death();
        }
    }

    void IHealthable.SetParameters(int health, int armor)
    {
        this.health = health;
        this.armor = armor;
    }
}
