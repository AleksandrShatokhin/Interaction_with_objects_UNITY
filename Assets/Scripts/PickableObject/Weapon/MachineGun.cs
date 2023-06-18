using System.Collections;
using UnityEngine;

public class MachineGun : WeaponManager
{
    private bool isCanShot;

    private void Start()
    {
        isCanShot = true;
    }

    public override void Shooting()
    {
        if (isCanShot == false)
        {
            return;
        }

        StartCoroutine(MachineGunShooting());
    }

    private IEnumerator MachineGunShooting()
    {
        int countBullet = 0;
        int maxBullet = 3;

        isCanShot = false;

        while (countBullet < maxBullet)
        {
            countBullet += 1;
            Instantiate(weaponSO.bulletPrefab, bulletStartPosition.position, bulletStartPosition.rotation);
            yield return new WaitForSeconds(0.2f);
        }

        isCanShot = true;
    }

    private void OnDisable()
    {
        isCanShot = true;
    }
}
