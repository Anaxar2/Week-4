using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Health")]
    public int healthPoints;
    public TextMeshProUGUI healthText;

    [Header("Timer")]
    public int timer;
    public TextMeshProUGUI timerText;

    [Header("Game Over")]
    public TextMeshProUGUI gameOverText;
    public Button restart;
    public Button quit;

    public float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime < 0) currentTime += Time.deltaTime;

        timerText.text = "Time:" + Mathf.RoundToInt(currentTime).ToString();
        healthText.text = "Health:" + healthPoints.ToString();
    }
}
