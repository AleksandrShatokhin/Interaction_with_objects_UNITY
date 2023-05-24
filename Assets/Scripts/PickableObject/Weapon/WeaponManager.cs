using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour, IShooting
{
    [SerializeField] protected WeaponSO weaponSO;
    [SerializeField] protected Transform bulletStartPosition;

    public virtual void Shooting() { }
}
