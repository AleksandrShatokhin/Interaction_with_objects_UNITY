using UnityEngine;

public class PlayerController : MonoBehaviour, IDeathable
{
    private Rigidbody rb_Player;
    [SerializeField] private MainUIController mainUIController;
    [SerializeField] private InventoryMain inventory;
    private int speedPlayer;

    public MainUIController GetMainUIController() => mainUIController;
    public InventoryMain GetInventoryController() => inventory;
    public void SpeedUpdate(int speed) => this.speedPlayer = speed;

    private void Start()
    {
        rb_Player = GetComponent<Rigidbody>();
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

    void IDeathable.Death()
    {
        RebootCurrentScene();
    }

    private void RebootCurrentScene() => UnityEngine.SceneManagement.SceneManager.LoadScene("OneScene");
}
