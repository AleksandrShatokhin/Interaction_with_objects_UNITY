using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmorManager : MonoBehaviour
{
    [SerializeField] private int speed, health, armor;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        collider.GetComponent<IPickableArmor>().SetParametersArmor(speed, health, armor);
        Destroy(this.gameObject);
    }
}
