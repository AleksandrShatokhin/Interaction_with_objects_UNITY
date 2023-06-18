using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour, IDeathable
{
    [SerializeField] private Transform targetPlayerPosition;
    [SerializeField] private Transform weaponPosition;

    private void Update()
    {
        transform.LookAt(targetPlayerPosition);
    }

    private void OnEnable()
    {
        StartCoroutine(EnemaBehavior());
    }

    private IEnumerator EnemaBehavior()
    {
        while (true)
        {
            int delay = Random.Range(2, 5);
            yield return new WaitForSeconds(delay);
            Attaking();
        }
    }

    private void Attaking()
    {
        foreach (Transform weaponInHand in weaponPosition)
        {
            if (weaponInHand.gameObject.activeInHierarchy == true)
            {
                weaponInHand.GetComponent<IShooting>().Shooting();
            }
        }
    }

    void IDeathable.Death()
    {
        Destroy(this.gameObject);
    }
}
