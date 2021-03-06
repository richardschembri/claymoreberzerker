﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

	public Animator TorsoAnim;					
    public float minspeed = 0.175f;
    public float maxspeed = 0.25f;
    private float? speed = null;
    public float Speed
    {
        get
        {
        if(speed == null)
            {
                speed = Random.Range(minspeed, maxspeed);
                var speedDiff = maxspeed - minspeed;
                var currSpeedDiff = speed - minspeed;
                if (currSpeedDiff < speedDiff / 4)
                {
                    AttackRange.gameObject.transform.localScale = new Vector3(0.8f, 1f, 1f);
                    Debug.Log("Reduced Attack Range");
                }else if(currSpeedDiff > (speedDiff * 3) / 4){
                    AttackRange.gameObject.transform.localScale = new Vector3(1.2f, 1f, 1f);
                    Debug.Log("Increased Attack Range");
                }
            }
            return (float)speed;
        }
        set
        {
            speed = value;
        }
    }
    public GameObject FullBody;
    public GameObject BodyParts;

    public BoxCollider2D AttackRange;

    public AudioSource AttackSound;
    public AudioSource[] DeathSounds;

    public ParticleSystem BloodSplatter;

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

    public int EnemyScore;
    //public Berzerker Player;
	// Use this for initialization
	void Start () {
	}

    void OnStartNewGame()
    {
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameControl.IsPaused)
        {
            return;
        }

        var lp = this.gameObject.transform.localPosition;
        if (this.gameObject.transform.localScale.x < 0)
        {
            this.gameObject.transform.localPosition = new Vector3(lp.x - Speed , lp.y, lp.z);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(lp.x + Speed , lp.y, lp.z);
        }

        if (this.gameObject.transform.localPosition.x < -2)
        {
            Destroy(this.gameObject);
        }

	}

    public void Attack()
    {
        TorsoAnim.SetTrigger(BerzerkerAttackLogic.ANIM_TRIGGER_ISATTACKING1);
        AttackSound.Play();
        //BloodSplatter.Play();
    }

    public void Die()
    {
        if (!IsAlive)
        {
            return;
        }
        IsAlive = false;
        BloodSplatter.Play();
        var deathSound = DeathSounds[Random.Range(0, DeathSounds.Length)];
        deathSound.Play();
        //Berzerker.HighScore += EnemyScore;
        ScoreManager.Instance.IncrementScore(EnemyScore);
        BodyParts.SetActive(false);
        FullBody.SetActive(true);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerWeapon")
        {
            Die();
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
