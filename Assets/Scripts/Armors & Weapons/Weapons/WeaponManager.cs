using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] protected GameObject projectile;
    [SerializeField] protected Transform spawnProjectilePosition;

    public void Shooting()
    {
        string tagWeapon = GetComponentInChildren<Transform>().gameObject.tag;

        switch (tagWeapon)
        {
            case "MachineGun" : 
                GetComponentInChildren<MachineGun>().Shot();
                break;

            case "HandGun" :
                GetComponentInChildren<HandGun>().Shot();
                break;
        }
    }
}
