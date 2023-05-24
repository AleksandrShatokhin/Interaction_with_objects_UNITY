using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : WeaponManager
{
    public override void Shooting()
    {
        Instantiate(weaponSO.bulletPrefab, bulletStartPosition.position, bulletStartPosition.rotation);
    }
}
