using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour {

	public float speed = 0.1f;			//Speed of the scrolling
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (GameControl.IsPaused)
        {
            return;
        }
		//Keep looping between 0 and 1
		float x = Mathf.Repeat (Time.time * speed, 1f);
		//Create the offset
		Vector2 offset = new Vector2 (x, 0);
		//Apply the offset to the material
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
