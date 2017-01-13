using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerzerkerAttackLogic : MonoBehaviour {

	Animator TorsoAnim;					//reference to the animator component
    bool mainSwing = true;
    public bool IsAttacking = false;
    

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
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Spave bar pressed");
            if (IsAttacking)
            {
                return;
            }
            if (mainSwing)
            {
                    TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING1);
                    mainSwing = false;
            }
            else
            {
                    TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING3);
                    mainSwing = true;
            }
        }	
    }
}
