using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameControl : MonoBehaviour {

    public static bool IsPaused = false;
    public GameObject ModalPopup;
    public Button RestartButton;
    public int AdCountDown = 5;
    int adCountDownIndex = 5;
    public Image AdIcon;
    public bool TestAds = true;
    private bool showAdvert = false;
    private bool ShowAdvert
    {

        get
        {
            return showAdvert; 
        }
        set
        {
            showAdvert = value;
            AdIcon.gameObject.SetActive(value);
        }
    }


    // Use this for initialization
    void Start () {
        adCountDownIndex = AdCountDown;
        ShowAdvert = false;

        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.Initialize("1285018", TestAds);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.R))
        {
            StartNewGame();
        }
        if (Input.GetKeyUp(KeyCode.P))
        {
            TogglePauseGame();
        }
	}

    void SendGlobalMessage(string methodName)
    {
        var gameObjects = FindObjectsOfType(typeof(GameObject));
        foreach(GameObject go in gameObjects)
        {
            go.SendMessage(methodName, SendMessageOptions.DontRequireReceiver);
        }
    }

    void TogglePaticleSystems()
    {
        var particleSystems = FindObjectsOfType(typeof(ParticleSystem));
        foreach (ParticleSystem ps in particleSystems)
        {
            if (IsPaused)
            {
                ps.Pause();
            }
            else
            {
                ps.Play();
            }
        }
    }

    public void TogglePauseGame()
    {
        IsPaused = !IsPaused;
        if (IsPaused)
        {
            SendGlobalMessage("OnPauseGame");
        }
        else
        {
            SendGlobalMessage("OnResumeGame");
        }
        TogglePaticleSystems();

    }

    public void StartNewGame()
    {
        if (ShowAdvert)
        {
            if (Advertisement.IsReady())
            {
                Advertisement.Show();
                ShowAdvert = false;
                StartCoroutine(StartAfterAvert());
            }
        }
        else
        {
            SendGlobalMessage("OnStartNewGame");
        }
    }

    IEnumerator StartAfterAvert()
    {
        yield return new WaitUntil(() => !Advertisement.isShowing);
        SendGlobalMessage("OnStartNewGame");
    }

    void OnStartNewGame()
    {
        ModalPopup.SetActive(false);
    }

    void OnPauseGame()
    {
        ModalPopup.SetActive(true);
        RestartButton.gameObject.SetActive(false);
    }

    void OnResumeGame()
    {
        ModalPopup.SetActive(false);
        RestartButton.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        SendGlobalMessage("OnGameOver");
    }

    void OnGameOver()
    {
        ModalPopup.SetActive(true);
        adCountDownIndex--;

        if ((adCountDownIndex <= 0) && (Advertisement.IsReady()))
        {
            ShowAdvert = true;
            adCountDownIndex = AdCountDown;
        }
        
    }


}
