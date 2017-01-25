using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public const int HIGHSCORE_COUNT = 10;
    public const string HIGHSCORE_KEY = "Highscore";
    public Text CurrentScoreText;
    public Text HighestScoreText;

    int currentScore = 0;
    
    List<int> highScores = new List<int>();

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

    void AddScore(int score )
    {
        int newScore;
        //string newName;
        int oldScore;
        //string oldName;
        newScore = score;
        //newName = name;
        for (int i = 0; i < HIGHSCORE_COUNT; i++)
        {
            if (PlayerPrefs.HasKey(i.ToString() + HIGHSCORE_KEY))
            {
                if (PlayerPrefs.GetInt(i.ToString() + HIGHSCORE_KEY) < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i.ToString() + HIGHSCORE_KEY);
                    //oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i.ToString() + HIGHSCORE_KEY, newScore);
                    //PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    //newName = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + HIGHSCORE_KEY, newScore);
                //PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                //newName = "";
            }
        }
    }

    // Use this for initialization
    void Start () {
        Instance = this;
        ResetScore();
        var foo = new List<int>();
        
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
