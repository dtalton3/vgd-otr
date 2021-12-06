using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame() {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
        AudioListener.volume = 1;
    }

    public void PlayGameAgain() {
        SceneManager.LoadScene("GameMenuScene");
        Time.timeScale = 1f;
        AudioListener.volume = 1;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
