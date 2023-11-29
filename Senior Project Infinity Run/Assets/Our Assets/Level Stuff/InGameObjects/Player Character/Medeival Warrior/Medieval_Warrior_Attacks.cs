using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medieval_Warrior_Attacks : MonoBehaviour
{
    public GameObject Attack1Collider;

    Medieval_Warrior_Animator_Controller Anim;


    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Medieval_Warrior_Animator_Controller>();

        Initialize();
    }

    void Update()
    {
        GetUserInput();
    }

    void GetUserInput()
    {
       
    }

    private void Initialize()
    {
        Attack1Collider.SetActive(false);
    }

    void DoAttack1()
    {
        Anim.PlayAttack1();
    }
    public void ToggleAttack1Collider()
    {
        Attack1Collider.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("attacked");
    }
}
