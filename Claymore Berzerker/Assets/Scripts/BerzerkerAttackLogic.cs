using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerzerkerAttackLogic : MonoBehaviour {

	Animator TorsoAnim;					//reference to the animator component
    bool mainSwing = true;
    public bool IsAttacking = false;
    int debugIndex = 0;
    

    public const string ANIM_TRIGGER_ISATTACKING1 = "IsAttacking1";
    public const string ANIM_TRIGGER_ISATTACKING2 = "IsAttacking2";
    public const string ANIM_TRIGGER_ISATTACKING3 = "IsAttacking3";
    // Use this for initialization
    void Start()
    {
        TorsoAnim = gameObject.transform.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (IsAttacking)
        {
            //return;
        }
        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(1))
        {
            Debug.Log("Spave bar pressed" + debugIndex.ToString());
            TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING1);
            debugIndex++;
            /*
            if (mainSwing)
            {
                TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING1);
                mainSwing = false;
                debugIndex++;
            }
            else
            {
                //TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING3);
                mainSwing = true;
            }
            */
        }
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
            Debug.Log("Spave bar pressed" + debugIndex.ToString());
            TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING1);
            debugIndex++;
            }
        }



            }
}
