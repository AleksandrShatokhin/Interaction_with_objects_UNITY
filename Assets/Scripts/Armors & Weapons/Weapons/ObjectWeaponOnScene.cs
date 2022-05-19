using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWeaponOnScene : WeaponManager
{
    [SerializeField] private GameObject weaponPrefab;

    private void Start()
    {
        weapon = new Weapon(weaponPrefab);
        saveData = new SaveDataWeapon();
        saveData.SetData(this.gameObject.tag, quantityBulletsInClip, quantityBulletsInPouch);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * 40 * Time.deltaTime);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}