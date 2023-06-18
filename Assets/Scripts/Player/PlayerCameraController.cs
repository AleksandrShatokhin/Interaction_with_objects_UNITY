using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Range(100, 1000)]
    [SerializeField] private float mouseSensetivity;

    private Transform targetPlayer;
    private float xRotation;

    private void Start()
    {
        targetPlayer = this.transform.parent;
    }

    void LateUpdate()
    {
        MoveCamera();
    }

    void MoveCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 45);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        targetPlayer.Rotate(Vector3.up * mouseX);
    }
}
