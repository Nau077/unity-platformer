using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField]
    private Rigidbody2D rigidBody;

    [SerializeField]
    public AnyStateAnimator animator;

    [SerializeField]
    private Collider2D collider;

    [SerializeField]
    private LayerMask groundLayer;

    public Rigidbody2D RigidBody
    {
        get
        {
            return rigidBody;
        }

        set
        {
            rigidBody = value;
        }
    }

    public AnyStateAnimator Animator { get => animator; }
    public LayerMask GroundLayer { get => groundLayer; }
    public Collider2D Collider { get => collider; }
}
