using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb_Player;

    [SerializeField] private float speedPlayer;
    [SerializeField] private int health;
    [SerializeField] private int experience;


    private void Start()
    {
        rb_Player = GetComponent<Rigidbody>();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }

    private void MovementPlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.right * horizontal + transform.forward * vertical;
        rb_Player.velocity = movement * speedPlayer;
    }

    public void PutOnArmor(float speed, int health, int experience)
    {
        this.speedPlayer += speed;
        this.health += health;
        this.experience += experience;
    }

    public void ResetArmor()
    {
        this.speedPlayer = 10;
        this.health = 10;
        this.experience = 10;
    }
}
