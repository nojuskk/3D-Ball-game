using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI scoreText;
    public GameObject endGamePanel;

    float timer;
    float highScoreTimer;

	// Use this for initialization
	void Start () {
        highScoreTimer = float.PositiveInfinity;
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreTimer = PlayerPrefs.GetFloat("HighScore");
        }
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        timerText.text = timer.ToString("F2");
        if(GameObject.FindGameObjectsWithTag("Collectable").Length == 0)
        {
            if(timer < highScoreTimer)
            {
                highScoreTimer = timer;
                PlayerPrefs.SetFloat("HighScore", timer);
            }
            highScoreText.text = highScoreTimer.ToString("F2");
            scoreText.text = timer.ToString("F2");
            endGamePanel.SetActive(true);
            Time.timeScale = 0;
        }
	}
}
