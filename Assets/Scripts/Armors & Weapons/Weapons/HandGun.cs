using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : WeaponManager
{
    private void Start()
    {
        quantityBulletsInClip = GameController.GetInstance().GetBulletsInClipHandgun();
        quantityBulletsInPouch = GameController.GetInstance().GetBulletsInPouchHandgun();

        weapon = new Weapon(quantityBulletsInClip, quantityBulletsInPouch);
        weapon.OutputBulletsTextOnScreen();
    }

    public void Shot()
    {
        Instantiate(projectile, spawnProjectilePosition.position, spawnProjectilePosition.rotation);
        weapon.ChangeBullets(-1);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
}
