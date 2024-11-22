using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    public float healthPoints;
    readonly Image currentHealthBar;

    [Header("Player")]
    public Transform player; // Reference to the player object
    public RectTransform healthBarUI; // Reference to the health bar RectTransform

    [Header("Timer")]
    public int timer;
    public TextMeshProUGUI timerText;
    public float currentTime = 0;

    [Header("Game Over")]
    public bool gameOver;
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button quitButton;

    public void Update()                  // Update is called once per frame
    {
        HealthTracker();
        Timer();
        FollowPlayer();
    }
    void HealthTracker()
    {
        currentHealthBar.fillAmount = healthPoints / 10;
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
    void FollowPlayer()
    {
        // Set the health bar position above the player
        Vector3 offset = new (4, 6, 0); // Adjust offset as needed
        healthBarUI.position = Camera.main.WorldToScreenPoint(player.position + offset);
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