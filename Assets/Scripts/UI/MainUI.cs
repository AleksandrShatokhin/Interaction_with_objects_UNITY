using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Text textCounterBullets;
    [SerializeField] private Text textArmorSpeed, textArmorHealth, textArmorExperience;

    private const string textSpeed = "Speed: ", textHealth = "Health: ", textExperience = "Experience: ";

    private void Start()
    {
        textCounterBullets.text = null;

        textArmorSpeed.text = textSpeed;
        textArmorHealth.text = textHealth;
        textArmorExperience.text = textExperience;
    }

    public void OutputTextBulletsOnScreen(int quantityBulletsInClip, int quantityBulletsInPouch)
    {
        textCounterBullets.text = quantityBulletsInClip.ToString() + " / " + quantityBulletsInPouch.ToString();
    }

    public void OutputTextArmorOnScreen(float speed, int health, int experience)
    {
        textArmorSpeed.text = textSpeed + speed.ToString();
        textArmorHealth.text = textHealth + health.ToString();
        textArmorExperience.text = textExperience + experience.ToString();
    }
}
