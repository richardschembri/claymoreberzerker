using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonUI : MonoBehaviour {

    public Sprite PauseSprite;
    public Sprite UnPauseSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnPauseGame()
    {
        this.GetComponent<Button>().image.sprite = UnPauseSprite;
    }

    void OnResumeGame()
    {
        this.GetComponent<Button>().image.sprite = PauseSprite;
    }
}
