using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    [SerializeField]
    public float Speed { get; set; }
    public Vector2 Direction { get; set; }

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float walkSpeed;

    [SerializeField]
    private float runSpeed;

    public float WalkSpeed { get => walkSpeed; }
    public float JumpForce { get => jumpForce; }
}