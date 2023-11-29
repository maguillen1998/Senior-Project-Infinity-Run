using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Stats : MonoBehaviour
{
    [System.NonSerializedAttribute]
    public int JumpsSinceGrounded = 0;
    public int MaxJumps = 10;
    public float JumpDelay = 0.25f;
    [System.NonSerializedAttribute]
    public float TimeOfLastJump = 0;

    [System.NonSerializedAttribute]
    public int CurrentHealth;

    public int MaxHealth = 1;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
    public float TimeSinceLastJump()
    {
        return Time.fixedTime - TimeOfLastJump;
    }
}
