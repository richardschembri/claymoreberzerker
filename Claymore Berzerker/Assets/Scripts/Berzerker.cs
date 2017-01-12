using UnityEngine;
using System.Collections;

public class Berzerker : MonoBehaviour {

	public Animator TorsoAnim;					//reference to the animator component
    bool mainSwing = true;
    public AudioSource SwordSound;
    public static int HighScore = 0;

    public const string ANIM_TRIGGER_ISATTACKING1 = "IsAttacking1";
    public const string ANIM_TRIGGER_ISATTACKING2 = "IsAttacking2";
    public const string ANIM_TRIGGER_ISATTACKING3 = "IsAttacking3";
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (mainSwing)
            {
                if (TorsoAnim.GetCurrentAnimatorStateInfo(0).IsName("Torso_Run"))
                {
                    TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING1);
                    mainSwing = false;
                    if (!SwordSound.isPlaying)
                    {
                        SwordSound.Play();
                    }
                }
            }
            else
            {
                if (TorsoAnim.GetCurrentAnimatorStateInfo(0).IsName("Torso_Run"))
                {
                    TorsoAnim.SetTrigger(ANIM_TRIGGER_ISATTACKING3);
                    mainSwing = true;
                    if (!SwordSound.isPlaying)
                    {
                        SwordSound.Play();
                    }
                }
            }

        }	
	}
}
