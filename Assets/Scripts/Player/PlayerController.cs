using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb_Player;

    [SerializeField] private Transform posForWeapon;
    [SerializeField] private List<GameObject> weapons;
    private GameObject currentWeapon;
    [SerializeField] private int counterWeapon = 0;

    [SerializeField] private float speedPlayer;
    [SerializeField] private int healthPlayer;
    [SerializeField] private int experiencePlayer;

    private void Start()
    {
        rb_Player = GetComponent<Rigidbody>();

        GameController.GetInstance().OutputTextArmorOnScreen(speedPlayer, healthPlayer, experiencePlayer);
    }

    private void Update()
    {
        SwitchWeaponInHand();
        Shooting();
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

    private void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (currentWeapon != null)
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    currentWeapon.GetComponentInParent<WeaponManager>().Shooting();
                }

                Vector3 direction = hit.point - currentWeapon.GetComponentInParent<WeaponManager>().GetSpawnProjectilePosition().position;
                currentWeapon.GetComponentInParent<WeaponManager>().SetDirectionSpawnBullet(direction);
            }
        }
    }

    private void SwitchWeaponInHand()
    {
        if (weapons.Count != 0)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
            {
                if (counterWeapon >= weapons.Count - 1)
                {
                    counterWeapon = 0;
                    TakeWeapon(counterWeapon);
                }
                else
                {
                    counterWeapon += 1;
                    TakeWeapon(counterWeapon);
                }
            }

            if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
            {
                if (counterWeapon <= 0)
                {
                    counterWeapon = weapons.Count - 1;
                    TakeWeapon(counterWeapon);
                }
                else
                {
                    counterWeapon -= 1;
                    TakeWeapon(counterWeapon);
                }
            }
        }
    }

    public void PutOnArmor(float speed, int health, int experience)
    {
        this.speedPlayer += speed;
        this.healthPlayer += health;
        this.experiencePlayer += experience;

        GameController.GetInstance().OutputTextArmorOnScreen(speedPlayer, healthPlayer, experiencePlayer);
    }

    public void ResetArmor()
    {
        this.speedPlayer = 10;
        this.healthPlayer = 10;
        this.experiencePlayer = 10;
    }

    private void ResetWeaponInHierarchy()
    {
        if (posForWeapon.childCount >= 1)
        {
            for (int i = 0; i < posForWeapon.childCount; i++)
            {
                Destroy(posForWeapon.GetChild(i).gameObject);
            }
        }
    }

    private void CheckListWeapon(GameObject weapon)
    {
        bool isSimilar = false;

        if (weapons.Count == 0)
        {
            weapons.Add(weapon);
        }
        else
        {
            for (int i = 0; i < weapons.Count; i++)
            {
                if (weapons[i] == weapon)
                {
                    isSimilar = true;
                }
            }

            if (isSimilar)
            {
                Debug.Log("Такое оружие уже есть!");
            }
            else
            {
                weapons.Add(weapon);
            }
        }
    }

    // использую для переключения оружия колесиком мыши
    private GameObject TakeWeapon(int id)
    {
        ResetWeaponInHierarchy();
        currentWeapon = Instantiate(weapons[id], posForWeapon.position, posForWeapon.rotation);
        currentWeapon.transform.SetParent(posForWeapon);

        return currentWeapon;
    }

    // использую при подборе нового оружие на сцене
    public GameObject TakeWeapon(GameObject weapon)
    {
        CheckListWeapon(weapon);

        ResetWeaponInHierarchy();

        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i] == weapon)
            {
                currentWeapon = Instantiate(weapons[i], posForWeapon.position, posForWeapon.rotation);
                currentWeapon.transform.SetParent(posForWeapon);
                break;
            }
        }

        return currentWeapon;
    }
}
