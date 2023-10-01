using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying_Eye_Stats : MonoBehaviour
{
    public int JumpsSinceGrounded = 0;
    public int MaxJumps = 10;
    public float JumpDelay = 0.25f;
    public float TimeOfLastJump = 0;

    public float TimeSinceLastJump()
    {
        return Time.fixedTime - TimeOfLastJump;
    }
}
