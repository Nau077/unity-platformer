using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField]
    private PlayerStats stats;
    
    [SerializeField]
    private PlayerComponents components;

    private PlayerReferences references;

    private PlayerUtilities utilities;

    private PlayerActions actions;

    public PlayerComponents Components
    {
        get
        {
            return components;
        }
    }
    public PlayerStats Stats { get => stats; }
    public PlayerActions Actions { get => actions; }
    public PlayerUtilities Utilities { get => utilities; set => utilities = value; }

    private void Awake() 
    {


    }

    public void Move(Transform transform)
    {

    }

    private void Start()
    {
        actions = new PlayerActions(this);
        utilities = new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Body_Idle"),
            new AnyStateAnimation(RIG.BODY, "Body_Walk"),
            new AnyStateAnimation(RIG.BODY, "Body_Jump"),
            new AnyStateAnimation(RIG.BODY, "Body_Fall"),

            new AnyStateAnimation(RIG.LEGS, "Legs_Idle"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Walk"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Jump"),
            new AnyStateAnimation(RIG.LEGS, "Legs_Fall"),
        };
                    
        components.Animator.AddAnimations(animations);
    }

    private void Update()
    {
        Utilities.HandleInput();
        utilities.HandleAir();
    }

    private void FixedUpdate()
    {
        Actions.Move(transform);
    }
}

/*
Грубо говоря ты в апдейте считываешь с клавиатуры кнопки влево и вправо как -1 и 1 и записываешь их в направление.

А в фиксед апдейте ты по этому направлению двигаешь обьект соответственно влево или вправо с помощью физики*/