using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWeaponOnScene : WeaponManager
{
    [SerializeField] private GameObject weaponPrefab;

    private void Start()
    {
        weapon = new Weapon(weaponPrefab);
        GameController.GetInstance().SetData(this.gameObject.tag, quantityBulletsInClip, quantityBulletsInPouch);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}