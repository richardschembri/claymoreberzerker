using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordLogic : MonoBehaviour {
    public bool IsEnemySword = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsEnemySword)
        {
            if (collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyLogic>().Die();
            }
        } 
    }

}
