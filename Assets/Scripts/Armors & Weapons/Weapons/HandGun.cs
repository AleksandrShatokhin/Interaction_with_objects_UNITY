using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : WeaponManager
{
    private void Start()
    {
        weapon = new Weapon(GameController.GetInstance().GetHandGun(), quantityBulletsInClip, quantityBulletsInPouch);
    }

    public void Shot()
    {
        Instantiate(projectile, spawnProjectilePosition.position, spawnProjectilePosition.rotation);
        weapon.ChangeBullets(-1);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
