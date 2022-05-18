using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponManager
{
    private void Start()
    {
        weapon = new Weapon(GameController.GetInstance().GetMichineGun(), quantityBulletsInClip, quantityBulletsInPouch);
    }

    public void Shot()
    {
        StartCoroutine(MachineGunShooting());
    }

    private IEnumerator MachineGunShooting()
    {
        int counter = 0;

        while (counter < 3)
        {
            counter++;
            Instantiate(projectile, spawnProjectilePosition.position, spawnProjectilePosition.rotation);
            weapon.ChangeBullets(-1);

            yield return new WaitForSeconds(0.1f);
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
