using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int healthPoints;
    public TextMeshProUGUI healthText;
    public int timer;
    public TextMeshProUGUI timerText;
    public float currentTime = 10;


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0) currentTime -= Time.deltaTime;

        timerText.text = "Time:" + Mathf.RoundToInt(currentTime).ToString();
        healthText.text = "Health:" + healthPoints.ToString();
    }
}
