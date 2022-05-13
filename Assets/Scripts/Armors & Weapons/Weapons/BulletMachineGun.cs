using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMachineGun : ProjectileManager
{
    private void Start()
    {
        rb_bullet = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        base.BulletDestroy();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
