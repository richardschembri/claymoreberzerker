using UnityEngine;
using System.Collections;
using System;

public class SpriteLayerOrderHandler : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<SpriteRenderer>().sortingOrder = Convert.ToInt32(this.transform.position.z);
	}
}
