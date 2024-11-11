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
    [SerializeField] Image totalHealthBar;
    [SerializeField] Image currentHealthBar;

    [Header("Timer")]
    public int timer;
    public TextMeshProUGUI timerText;
    public float currentTime = 0;

    [Header("Game Over")]
    public bool gameOver;
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button quitButton;

    private void Start()
    {
        totalHealthBar.fillAmount = healthPoints / 10;
    }

    void Update()                  // Update is called once per frame
    {
        Timer();
        currentHealthBar.fillAmount =healthPoints / 10;
        //healthText.text = "Health:" + healthPoints.ToString();
    }
    public void Timer()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);

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