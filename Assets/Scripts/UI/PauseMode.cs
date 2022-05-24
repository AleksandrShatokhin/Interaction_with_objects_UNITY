using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMode : MonoBehaviour
{
    [SerializeField] private Button continueButton, restartButton, exitButton;

    private void Start()
    {
        continueButton.onClick.AddListener(ToContinue);
        restartButton.onClick.AddListener(ToRestart);
        exitButton.onClick.AddListener(ToExit);
    }

    private void ToContinue()
    {
        GameController.GetInstance().GetPauseMode();
    }

    private void ToRestart()
    {
        SceneManager.LoadScene("OneScene");
        Time.timeScale = 1.0f;
    }

    private void ToExit()
    {
        Application.Quit();
    }
}
