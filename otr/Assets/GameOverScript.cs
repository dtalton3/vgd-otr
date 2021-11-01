using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    public Text pointsText;
    public void Setup(float time)
    {
        gameObject.SetActive(true);
        pointsText.text = "You lasted " + time.ToString() + " seconds!";
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
