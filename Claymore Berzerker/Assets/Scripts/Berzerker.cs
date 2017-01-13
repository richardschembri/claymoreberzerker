using UnityEngine;
using System.Collections;

public class Berzerker : MonoBehaviour {

    public static int HighScore = 0;

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
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}
}
