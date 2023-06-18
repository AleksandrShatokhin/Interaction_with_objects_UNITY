using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private int forceRate;
    private Rigidbody rb_Bullet;

    private void Start()
    {
        rb_Bullet = this.GetComponent<Rigidbody>();
        Destroy(this.gameObject, 1.0f);
    }

    private void FixedUpdate()
    {
        rb_Bullet.AddForce(transform.forward * forceRate, ForceMode.Impulse);
    }
}
