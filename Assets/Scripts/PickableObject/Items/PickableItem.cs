using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public ItemSO itemSO;

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<IPickableItem>().PickableItem(this);
            this.gameObject.SetActive(false);
        }
    }
}
