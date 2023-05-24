using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private int bulletDamage;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IHealthable>()?.TakeDamage(bulletDamage);
        Destroy(this.gameObject);
    }
}
