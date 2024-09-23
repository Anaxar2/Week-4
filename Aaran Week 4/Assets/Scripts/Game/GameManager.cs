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
    public float currentTime = 0;

    [Header("Game Over")]
    public GameObject gameOver;
    public Button restartButton;
    public Button quitButton;

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
        timerText.text = "Time:" + Mathf.RoundToInt(currentTime).ToString();

        if (timer == 0)
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
        Application.Quit();
    }
}
#endif