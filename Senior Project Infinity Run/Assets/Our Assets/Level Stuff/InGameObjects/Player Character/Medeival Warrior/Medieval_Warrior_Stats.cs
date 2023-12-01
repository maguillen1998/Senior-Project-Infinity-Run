using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medieval_Warrior_Stats : MonoBehaviour
{
    [System.NonSerializedAttribute]
    public int JumpsSinceGrounded = 0;
    public int MaxJumps = 10;
    public float JumpDelay = 0.25f;
    [System.NonSerializedAttribute]
    public float TimeOfLastJump = 0;
    public float MaxJumpDuration = 0.3f;

    [System.NonSerializedAttribute]
    public int CoinsCollected = 0;

    public int MaxHealth = 1;

    [System.NonSerializedAttribute]
    public int CurrentHealth;

    public float TimeSinceLastJump()
    {
        return Time.timeSinceLevelLoad - TimeOfLastJump;
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
