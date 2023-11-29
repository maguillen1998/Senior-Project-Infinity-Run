using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Character_Stats : MonoBehaviour
{
    public int CoinsCollected;
    public int HealthPoints;
    public int MaxJumps;
    public int RemainingJumps;
    // Start is called before the first frame update
    void Start()
    {
        HealthPoints = 1;
        CoinsCollected = 0;
        MaxJumps = 2;
        RemainingJumps = MaxJumps;
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
