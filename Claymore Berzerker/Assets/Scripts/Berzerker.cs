using UnityEngine;
using System.Collections;

public class Berzerker : MonoBehaviour {

    public static int HighScore = 0;


    float startX = 0;
    public float speed = 1f;
    private bool isAlive = true;
    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
        private set
        {
            isAlive = value;
        }
    }

    public GameObject FullBody;
    public GameObject BodyParts;
    // Use this for initialization
    void Start () {
        startX = gameObject.transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameControl.IsPaused)
        {
            return;
        }
        if (!IsAlive)
        {
            var lp = this.gameObject.transform.localPosition;
            if (this.gameObject.transform.localScale.x < 0)
            {
                this.gameObject.transform.localPosition = new Vector3(lp.x - speed, lp.y, lp.z);
            }
            else
            {
                this.gameObject.transform.localPosition = new Vector3(lp.x + speed, lp.y, lp.z);
            }

            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began)
                {
                    Respawn();
                }
            }
        }

	}

    void OnRestartGame()
    {
        Respawn();
    }

    public void Respawn()
    {
        IsAlive = true;

        BodyParts.SetActive(true);
        FullBody.SetActive(false);

        var lp = gameObject.transform.localPosition;
        gameObject.transform.localPosition = new Vector3(startX, lp.y, lp.z);
        Berzerker.HighScore = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyWeapon")
        {
            IsAlive = false;
            BodyParts.SetActive(false);
            FullBody.SetActive(true);
        }
    }


    void OnPauseGame()
    {
        playPauseAnim(true);
    }

    void OnResumeGame()
    {
        playPauseAnim();
    }


    void playPauseAnim(bool pauseAnim = false)
    {
        var enemyAnims = this.gameObject.GetComponentsInChildren<Animator>();
        foreach(var ea in enemyAnims)
        {
            ea.enabled = !pauseAnim;
        }
    }

}
