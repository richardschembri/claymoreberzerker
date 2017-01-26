using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public const int HIGHSCORE_COUNT = 10;
    public const string HIGHSCORE_KEY = "Highscore";
    public Text CurrentScoreText;
    public Text TopScore;
    public Text TopScores;

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

    Dictionary<string, int> GetTopScores()
    {
        var highScoreDict = new Dictionary<string, int>();

        for (int i = 0; i < HIGHSCORE_COUNT; i++)
        {
            var key = i.ToString() + HIGHSCORE_KEY;
            highScoreDict.Add(key, PlayerPrefs.GetInt(key, 0));
        }

        return highScoreDict; 
        
    }

    void ShowTopScores()
    {
        var topScoresDict = GetTopScores();
        var sbTopScores = new StringBuilder();
        int i = 1;
        foreach (var e in topScoresDict)
        {
            if (i < 10)
            {
                sbTopScores.AppendLine(string.Format("{0}.  {1}", i, e.Value));
            }
            else
            {
                sbTopScores.AppendLine(string.Format("{0}. {1}", i, e.Value));
            }
            i++;
        }

        TopScores.text = sbTopScores.ToString();
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
            var key = i.ToString() + HIGHSCORE_KEY;
            if (PlayerPrefs.HasKey(key))
            {
                if (PlayerPrefs.GetInt(key) < newScore)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(key);
                    //oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(key, newScore);
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
    void Start()
    {
        Instance = this;
        ResetScore();

    }

    void getTopScore()
    {
        var topScoreKey = "0" + HIGHSCORE_KEY;
        var topScore = PlayerPrefs.GetInt(topScoreKey);
        TopScore.text = topScore.ToString();
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        getTopScore();
    }

    // Update is called once per frame
	void Update () {
	}

    public void IncrementScore(int by)
    {
        CurrentScore += by;
    }

    void OnGameOver()
    {
        AddScore(CurrentScore);
        ShowTopScores();
        ResetScore();
    }
}
