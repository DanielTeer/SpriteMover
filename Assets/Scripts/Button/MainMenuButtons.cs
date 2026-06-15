using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{

    public void ChangeToGameplay()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateGameplay();
        }
    }

    public void ChangeToOptions()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateOptionsScreen();
        }
    }

    public void ChangeToCredits()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateCreditsScreen();
        }
    }

    public void ChangeToTitleScreen()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateTitleScreen();
        }
    }
    public void ChangeToMainMenuScreen()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ActivateMainMenuScreen();
        }
    }
}