using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : WeaponManager
{
    private void Start()
    {
        saveData = new SaveDataWeapon();

        quantityBulletsInClip = saveData.GetBulletsInClipMachineGun();
        quantityBulletsInPouch = saveData.GetBulletsInPouchMachineGun();

        weapon = new Weapon(quantityBulletsInClip, quantityBulletsInPouch);
        weapon.OutputBulletsTextOnScreen();
    }

    public void Shot()
    {
        if (weapon.IsCanShot())
        {
            StartCoroutine(MachineGunShooting());
        }
        else
        {
            Debug.Log("Патронов больше нет!");
        }
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

    public void SaveData()
    {
        saveData.SetData(this.gameObject.tag, weapon.GetQuantityBulletsInClip(), weapon.GetQuantityBulletsInPouch());
    }

    protected override void OnDestroy()
    {
        SaveData();
    }
}
