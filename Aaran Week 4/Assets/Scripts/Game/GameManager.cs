using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    public int healthPoints;
    public TextMeshProUGUI healthText;

    [Header("Timer")]
    public int timer;
    public TextMeshProUGUI timerText;
    public float currentTime = 0;

    [Header("Game Over")]
    public bool gameOver;
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button quitButton;

    void Update()                  // Update is called once per frame
    {
        Timer();
        healthText.text = "Health:" + healthPoints.ToString();
    }

    public void Timer()
    {
        timerText.text = "Time:" + Mathf.FloorToInt(currentTime).ToString();

        if (timer == 0 && gameOver == false)
        {
            currentTime += Time.deltaTime;
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
    }
#endif
    }
}