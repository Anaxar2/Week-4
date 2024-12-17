using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    public float healthPoints;
    public Image currentHealthBar;

    [Header("Player")]
    public Transform player;            // Reference to the player object
    public RectTransform healthBarUI;   // Reference to the health bar RectTransform

    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float currentTime = 0;

    [Header("Rings")]
    public int rings;
    public TextMeshProUGUI ringText;

    [Header("Score")]
    public int score;
    public TextMeshProUGUI scoreText;

    [Header("Game Over")]
    public bool gameOver;
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button quitButton;

    public void Update()                  // Update is called once per frame
    {
        RingTracker();
        HealthTracker();
        Timer();
        FollowPlayer();
        TotalScore();
    }
    void RingTracker()
    {
        ringText.text = "Rings: " + rings;
    }
    void HealthTracker()
    {
        currentHealthBar.fillAmount = healthPoints / 10;
    }
    public void Timer()
    {
        if (gameOver == false)
        {
            currentTime += Time.deltaTime;
        }

        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime - minutes * 60);
        timerText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
    }
    void FollowPlayer()
    {
        // Set the health bar position above the player
        Vector3 offset = new (4, 6, 0); // Adjust offset as needed
        healthBarUI.position = Camera.main.WorldToScreenPoint(player.position + offset);
    }
    public void TotalScore()
    {
        float normalizedTime = currentTime / 60f; // Normalize time to minutes
        score = (int)(normalizedTime * rings);
        scoreText.text = "Total: " + Mathf.RoundToInt(score);
    }  
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}