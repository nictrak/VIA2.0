using System;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class MonsterStateMachine : MonoBehaviour
{
    [SerializeField]
    private MonsterState initialState;
    [SerializeField]
    private string animatorStringHead;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Animator effectAnimator;
    [SerializeField]
    private List<MonsterState> statesHashSequence;
    [SerializeField]
    private List<MonsterStateBehaviour> states;
    [SerializeField]
    private List<string> stringAnimators;
    [SerializeField]
    private bool isHurtBreak;
    [SerializeField]
    private bool isHaveEightDirection;
    [SerializeField]
    private TriggerRange mostOuterRange;
    [SerializeField]
    private List<MonsterState> tokenStates;

    // Use For attack direction
    private Vector2 lastestNonZeroMoveDirection;
    public Vector2 LastestNonZeroMoveDirection { get => lastestNonZeroMoveDirection; set => lastestNonZeroMoveDirection = value; }

    // string directionString = "S";
    private string directionString = "S";
    private Boolean atttackPlayEffect ;
    private Dictionary<MonsterState, MonsterStateBehaviour> statesHash;
    private Dictionary<MonsterState, string> stringAnimatorsHash;
    private AIDestinationSetter aIDestinationSetter;
    private FlipToPlayer flipToPlayer;

    private MonsterState currentState;
    public MonsterState CurrentState { get => currentState; set => currentState = value; }
    private Health health;
    private MonsterTokenController monsterTokenController;
    private MonsterAttributes monsterAttributes;

    // private static readonly string[] directions = { "N", "NW", "W", "SW", "S", "SW", "W", "NW" };
    private static readonly string[] directions = { "N", "NW", "W", "SW", "S", "SW", "W", "NW" };
    //Hot Fix: Attack flip 
    private static readonly string[] directionsAttack = { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };
    
    private Dictionary<string, float[]> directionsEffect ;
    public enum MonsterState
    {
        Setup,
        Meet,
        Aggro,
        Attack,
        Hurt,
        Dead,
        Free,
        Charge,
        Warning,
        Wait,
        Aim
    }

    MonsterState[] tokenState = {
        MonsterState.Attack,
        MonsterState.Charge
    };

    private bool startFreezingAnimation = false;
    private bool alreadyFreezingAnimation = false;

    private string previousAnimationstring = "";

    // Start is called before the first frame update
    private void Start()
    {
        SetupStatesHash();
        SetupStringAnimatorsHash();
        currentState = initialState;
        StartState(currentState);
        health = GetComponent<Health>();
        aIDestinationSetter = GetComponent<AIDestinationSetter>();
        flipToPlayer = GetComponent<FlipToPlayer>();

        lastestNonZeroMoveDirection = new Vector2(0, -1);
        if(monsterTokenController == null)
        {
            monsterTokenController = Resources.FindObjectsOfTypeAll<MonsterTokenController>()[0];
        }
        if (monsterAttributes == null){
            monsterAttributes = this.transform.root.gameObject.GetComponent<MonsterAttributes>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDestination();
        if(startFreezingAnimation) {
            if(!alreadyFreezingAnimation){
                PlayAnimation(currentState);
                alreadyFreezingAnimation = true;
                flipToPlayer.canFlip = false;
            }
        } else {
            PlayAnimation(currentState);
        }
    }

    void PlayAnimation(MonsterState state) {
        string animationString = CreateAnimatorString(state);
        if(animationString != previousAnimationstring){
            animator.Play(animationString);
            previousAnimationstring = animationString;
        }
    }

    private void FixedUpdate()
    {
        RunStatePerFrame(currentState);
    }
    private void SetupStatesHash()
    {
        statesHash = new Dictionary<MonsterState, MonsterStateBehaviour>();
        for(int i = 0; i < statesHashSequence.Count; i++)
        {
            statesHash.Add(statesHashSequence[i], states[i]);
        }
    }
    private void SetupStringAnimatorsHash()
    {
        stringAnimatorsHash = new Dictionary<MonsterState, string>();
        for (int i = 0; i < statesHashSequence.Count; i++)
        {
            stringAnimatorsHash.Add(statesHashSequence[i], stringAnimators[i]);
        }
    }
    public void ChangeState(MonsterState nextState)
    {
        if(nextState != currentState)
        {
            if(tokenStates.Contains(nextState)){
                if(monsterTokenController.RequestToken(monsterAttributes.monsterType != monsterType.Friendly)){    
                    ExitState(currentState);
                    currentState = nextState;
                    StartState(currentState);
                }
            } else {
                ExitState(currentState);
                currentState = nextState;
                StartState(currentState);
            }
        }
    }
    private void StartState(MonsterState state)
    {
        statesHash[state].StartState();
        if(state == MonsterState.Attack){
            startFreezingAnimation = true;
        }
    }
    private void ExitState(MonsterState state)
    {
        statesHash[state].ExitState();
        if(state == MonsterState.Attack){
            startFreezingAnimation = false;
            alreadyFreezingAnimation = false;
            flipToPlayer.canFlip = true;
        }
    }
    private string CreateAnimatorString(MonsterState state)
    {
        string result = animatorStringHead;
        string directionString = "S";
        string attackDirection = "" ;
        if (isHaveEightDirection && currentState != MonsterState.Hurt && currentState != MonsterState.Dead)
        {
            if (aIDestinationSetter.target != null)
            {
                Vector2 direction = (aIDestinationSetter.target.transform.position - transform.position).normalized;
                LastestNonZeroMoveDirection = direction;
                if (flipToPlayer.IsReverse)
                {
                    direction = direction * -1;
                }
                directionString = directions[DirectionToIndex(direction, 8)];
                attackDirection = directionsAttack[DirectionToIndex(direction, 8)];

            }
            result = result + stringAnimatorsHash[state] + " " + directionString;

            if (currentState == MonsterState.Attack ) {
                // Debug.Log("basic_melee_effect"+ " " + directionString);
                // effectAnimator.Play("basic_melee_effect"+" "+"W");
                effectAnimator.Play("basic_melee_effect"+ " " + attackDirection);
                
            } else if (currentState != MonsterState.Attack ) {
                effectAnimator.Play("Idle");
            }
        }
        else
        {
            result = result + stringAnimatorsHash[state];
        }
        return result;
    }
    private void RunStatePerFrame(MonsterState state)
    {
        MonsterState nextState;
        nextState = statesHash[state].RunState();
        if (isHurtBreak)
        {
            if (health.IsHurt && health.IsKnockback)
            {
                nextState = MonsterState.Hurt;
            }
        }
        if (health.IsDead)
        {
            nextState = MonsterState.Dead;
        }
        ChangeState(nextState);
    }
    private int DirectionToIndex(Vector2 dir, int sliceCount)
    {
        //get the normalized direction
        Vector2 normDir = dir.normalized;
        //calculate how many degrees one slice is
        float step = 360f / sliceCount;
        //calculate how many degress half a slice is.
        //we need this to offset the pie, so that the North (UP) slice is aligned in the center
        float halfstep = step / 2;
        //get the angle from -180 to 180 of the direction vector relative to the Up vector.
        //this will return the angle between dir and North.
        float angle = Vector2.SignedAngle(Vector2.up, normDir);
        //add the halfslice offset
        angle += halfstep;
        //if angle is negative, then let's make it positive by adding 360 to wrap it around.
        if (angle < 0)
        {
            angle += 360;
        }
        //calculate the amount of steps required to reach this angle
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }
    private void UpdateDestination()
    {
        GameObject newTarget = mostOuterRange.CalNearestObject();
        if(newTarget != null)
        {
            aIDestinationSetter.target = newTarget.transform;
        }
    }
}

