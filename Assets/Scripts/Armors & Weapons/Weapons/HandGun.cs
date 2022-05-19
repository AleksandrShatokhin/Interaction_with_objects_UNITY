using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun : WeaponManager
{
    private void Start()
    {
        saveData = new SaveDataWeapon();

        quantityBulletsInClip = saveData.GetBulletsInClipHandGun();
        quantityBulletsInPouch = saveData.GetBulletsInPouchHandGun();

        weapon = new Weapon(quantityBulletsInClip, quantityBulletsInPouch);
        weapon.OutputBulletsTextOnScreen();
    }

    public void Shot()
    {
        if (weapon.IsCanShot())
        {
            Instantiate(projectile, spawnProjectilePosition.position, spawnProjectilePosition.rotation);
            weapon.ChangeBullets(-1);
        }
        else
        {
            Debug.Log("Патронов больше нет!");
        }
    }

    public void SaveData()
    {
        saveData.SetData(this.gameObject.tag, weapon.GetQuantityBulletsInClip(), weapon.GetQuantityBulletsInPouch());
    }

    protected override void OnDestroy()
    {
        SaveData();
    }
}
