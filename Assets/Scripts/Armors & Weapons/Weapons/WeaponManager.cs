using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    protected Weapon weapon;

    [SerializeField] protected GameObject projectile;
    [SerializeField] protected Transform spawnProjectilePosition;

    [SerializeField] protected int quantityBulletsInClip, quantityBulletsInPouch;

    protected Vector3 directionSpawnBullet;

    public void Shooting()
    {
        string tagWeapon = GetComponentInChildren<Transform>().gameObject.tag;

        switch (tagWeapon)
        {
            case "MachineGun":
                GetComponentInChildren<MachineGun>().Shot();
                break;

            case "HandGun":
                GetComponentInChildren<HandGun>().Shot();
                break;
        }
    }

    // для создания луча при стрельбе корректирую направление поворота спаунера пули
    // чтоб стрельба происходила в центр экрана (в прицел)
    public Vector3 SetDirectionSpawnBullet(Vector3 direction) => directionSpawnBullet = direction;
    public Transform GetSpawnProjectilePosition() => spawnProjectilePosition;

    virtual protected void OnDestroy()
    {
        GameController.GetInstance().SetData(this.gameObject.tag, weapon.GetQuantityBulletsInClip(), weapon.GetQuantityBulletsInPouch());
    }

    virtual protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            weapon.PlayerTakesWeapon();
            weapon.OutputBulletsTextOnScreen();
        }
    }
}
