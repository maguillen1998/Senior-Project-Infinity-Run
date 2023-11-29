using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_State_Manager : MonoBehaviour
{
    public GameObject PostGameMenu;
    // Start is called before the first frame update
    void Start()
    {
        PostGameMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        DisplayDeathScreen();
    }

    void DisplayDeathScreen()
    {
        PostGameMenu.SetActive(true);
    }
}
