using TMPro;
using UnityEngine;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textAboutPlayerSpeed, textAboutPlayerHealth, textAboutPlayerArmor, textCounterBullets;

    public void SetPlayerParametersOnScreen(int speed, int health, int armor)
    {
        textAboutPlayerSpeed.text = TextDatabase.ScreenTextSpeedPlayer + speed;
        textAboutPlayerHealth.text = TextDatabase.ScreenTextHealthPlayer + health;
        textAboutPlayerArmor.text = TextDatabase.ScreenTextArmorPlayer + armor;
    }

    public void SetPlayerCounterBulletsOnSceen(int current, int all)
    {
        textCounterBullets.text = current + " / " + all;
    }
}
