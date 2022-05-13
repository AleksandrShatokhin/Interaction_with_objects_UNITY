using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    private float forceRate = 40;
    protected Rigidbody rb_bullet;

    virtual protected void FixedUpdate()
    {
        rb_bullet.AddForce(transform.forward * forceRate, ForceMode.Impulse);
    }

    protected void BulletDestroy()
    {
        Destroy(gameObject, 3.0f);
    }
}
