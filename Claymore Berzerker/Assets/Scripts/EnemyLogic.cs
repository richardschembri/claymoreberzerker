using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour {

    public float speed = 1f;
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
	}

    void OnTriggerEnter(Collider other)
    {
    
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Hit");
        if (collision.tag == "PlayerWeapon")
        {
            Debug.Log("Enemy Hit");
        }
    }
}
