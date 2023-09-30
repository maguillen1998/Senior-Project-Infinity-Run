using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Eye_Animator_Script : MonoBehaviour
{
    Animator MyAnimator;
    // Start is called before the first frame update
    void Start()
    {
        MyAnimator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f"))
        {
            TriggerAttackAnimation();
        }
        if (Input.GetKey("g"))
        {
            TriggerTookHitAnimation();
        }
        if (Input.GetKey("h"))
        {
            TriggerDeathAnimation();
        }
    }

    public void TriggerAttackAnimation()
    {
        string animation = "Attacking";
        MyAnimator.SetBool(animation, true);
    }

    public void TriggerTookHitAnimation()
    {
        string animation = "Took Hit";
        MyAnimator.SetBool(animation, true);
    }

    public void TriggerDeathAnimation()
    {
        string animation = "Died";
        MyAnimator.SetBool(animation, true);
    }
}
