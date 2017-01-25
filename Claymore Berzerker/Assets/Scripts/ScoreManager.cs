using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public Text CurrentScoreText;
    public Text HighestScoreText;

    int currentScore = 0;
    static ScoreManager _instance;
    public static ScoreManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }


    int CurrentScore
    {
        get
        {
            return currentScore;
        }set
        {
            currentScore = value;
            CurrentScoreText.text = currentScore.ToString();
        }
    }
    int HighestScore
    {
        get
        {
            return PlayerPrefs.GetInt("Score1", 0);
        }
        set
        {
            PlayerPrefs.SetInt("Score1", value);
            HighestScoreText.text = value.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        Instance = this;
        ResetScore();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        HighestScoreText.text = HighestScore.ToString();
    }

    // Update is called once per frame
	void Update () {
	}

    public void IncrementScore(int by)
    {
        CurrentScore += by;
        if (HighestScore < CurrentScore)
        {
            HighestScore = CurrentScore; 
        }
    }
}
