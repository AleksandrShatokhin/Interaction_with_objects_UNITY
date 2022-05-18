using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorRed : ArmorManager
{
    private void Start()
    {
        armor = new Armor(speed, health, experience);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
