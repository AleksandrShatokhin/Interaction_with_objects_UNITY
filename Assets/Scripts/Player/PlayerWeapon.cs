using UnityEngine;

public class PlayerWeapon : MonoBehaviour, IPickableWeapon
{
    [SerializeField] private Transform weaponPositionInHand;
    private int indicatorWeapon;

    private void Start()
    {
        indicatorWeapon = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shot();
        }

        SwitchWeaponInHand();
    }

    private void Shot()
    {
        foreach (Transform weaponInHand in weaponPositionInHand)
        {
            if (weaponInHand.gameObject.activeInHierarchy == true)
            {
                weaponInHand.GetComponent<IShooting>().Shooting();
            }
        }
    }

    void IPickableWeapon.PickableWeapon(GameObject weapon)
    {
        if (weaponPositionInHand.childCount > 0)
        {
            foreach (Transform weaponInHand in weaponPositionInHand)
            {
                weaponInHand.gameObject.SetActive(false);
            }
        }

        GameObject createdWeapon = Instantiate(weapon, weaponPositionInHand.position, weaponPositionInHand.rotation);
        createdWeapon.transform.SetParent(weaponPositionInHand);

        indicatorWeapon = weaponPositionInHand.childCount - 1;
    }

    private void SwitchWeaponInHand()
    {
        int minCountToScroll = 2;

        if (weaponPositionInHand.childCount >= minCountToScroll)
        {
            ScrollUp();
            ScrollBottom();
        }
    }

    private void ScrollUp()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f)
        {
            weaponPositionInHand.GetChild(indicatorWeapon).gameObject.SetActive(false);
            indicatorWeapon = (indicatorWeapon >= weaponPositionInHand.childCount - 1) ? indicatorWeapon = 0 : indicatorWeapon += 1;
            weaponPositionInHand.GetChild(indicatorWeapon).gameObject.SetActive(true);
        }
    }

    private void ScrollBottom()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f)
        {
            weaponPositionInHand.GetChild(indicatorWeapon).gameObject.SetActive(false);
            indicatorWeapon = (indicatorWeapon <= 0) ? weaponPositionInHand.childCount - 1 : indicatorWeapon -= 1;
            weaponPositionInHand.GetChild(indicatorWeapon).gameObject.SetActive(true);
        }
    }
}
