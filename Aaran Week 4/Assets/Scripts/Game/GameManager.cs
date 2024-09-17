using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    public int healthPoints;
    public TextMeshProUGUI healthText;

    [Header("Timer")]
    public int timer;
    public TextMeshProUGUI timerText;

    [Header("Game Over")]
    public GameObject gameOver;
    public Button restartButton;
    public Button quitButton;

    public float currentTime = 0;
    // Start is called before the first frame update
   /* void Start()
    {

    }*/
    void Update()                  // Update is called once per frame
    {
        Timer();
        healthText.text = "Health:" + healthPoints.ToString();
    }

    public void Timer()
    {
        if (currentTime == 0) currentTime += Time.deltaTime;
        timerText.text = "Time:" + Mathf.RoundToInt(currentTime).ToString();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        Application.Quit();
    }
}
#endif