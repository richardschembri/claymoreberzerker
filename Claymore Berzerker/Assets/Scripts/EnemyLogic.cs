using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

	public Animator TorsoAnim;					
    public float speed = 1f;
    public bool IsAlive = true;
    public int EnemyScore;
    public Berzerker Player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () { 

        var lp = this.gameObject.transform.localPosition;
        if (this.gameObject.transform.localScale.x < 0)
        {
            this.gameObject.transform.localPosition = new Vector3(lp.x - speed , lp.y, lp.z);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(lp.x + speed , lp.y, lp.z);
        }

        if (this.gameObject.transform.localPosition.x < -2)
        {
            Destroy(this.gameObject);
        }

        /*
        if (Player.transform.localPosition.x < gameObject.transform.localPosition.x)
        {
            TorsoAnim.SetTrigger(Berzerker.ANIM_TRIGGER_ISATTACKING1);
        }
        */

	}

    public void Attack()
    {
        TorsoAnim.SetTrigger(Berzerker.ANIM_TRIGGER_ISATTACKING1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerWeapon")
        {
            IsAlive = false;
            Berzerker.HighScore += EnemyScore;

        }
    }
}
