using UnityEngine;

public class PlayerArmor : MonoBehaviour, IPickableArmor
{
    private MainUIController mainUIController;

    [SerializeField] private int speedPlayer;
    [SerializeField] private int healthPlayer;
    [SerializeField] private int armorPlayer;

    private void Start()
    {
        mainUIController = GetComponent<PlayerController>().GetMainUIController();
        SentPlayerParametersOnScreen();
    }

    void IPickableArmor.SetParametersArmor(int speed, int health, int armor)
    {
        this.speedPlayer = this.speedPlayer + speed;
        this.healthPlayer = this.healthPlayer + health;
        this.armorPlayer = this.armorPlayer + armor;

        SentPlayerParametersOnScreen();
    }

    private void SentPlayerParametersOnScreen()
    {
        mainUIController.SetPlayerParametersOnScreen(speedPlayer, healthPlayer, armorPlayer);
        GetComponent<PlayerController>().SpeedUpdate(this.speedPlayer);
        GetComponent<IHealthable>().SetHealthParameters(healthPlayer, armorPlayer);
    }
}
