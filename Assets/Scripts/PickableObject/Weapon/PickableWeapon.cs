using UnityEngine;

public class PickableWeapon : MonoBehaviour
{
    [SerializeField] private GameObject weaponInHand;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<IPickableWeapon>().PickableWeapon(weaponInHand);
            Destroy(this.gameObject);
        }
    }
}
