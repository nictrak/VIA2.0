using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{

    [SerializeField] private int energy;

    public int Energy {
        get { return energy; }
    }

    [SerializeField]
    private BossState initialState;
    [SerializeField]
    private string animatorStringHead;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private List<BossState> statesHashSequence;
    [SerializeField]
    private List<BossStateBehaviour> states;
    [SerializeField]
    private List<string> stringAnimators;
    [SerializeField]
    private bool isHurtBreak;

    private Dictionary<BossState, BossStateBehaviour> statesHash;
    private Dictionary<BossState, string> stringAnimatorsHash;

    private BossState currentState;
    private Health health;

    public enum BossState
    {
        Check,
        Random,
        Charge,
        Attack,
        Launch,
        Wait,
        //Hurt,
        Dead
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupStatesHash();
        SetupStringAnimatorsHash();
        currentState = initialState;
        StartState(currentState);
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        RunStatePerFrame(currentState);
    }
    private void SetupStatesHash()
    {
        statesHash = new Dictionary<BossState, BossStateBehaviour>();
        for(int i = 0; i < statesHashSequence.Count; i++)
        {
            statesHash.Add(statesHashSequence[i], states[i]);
        }
    }
    private void SetupStringAnimatorsHash()
    {
        stringAnimatorsHash = new Dictionary<BossState, string>();
        for (int i = 0; i < statesHashSequence.Count; i++)
        {
            stringAnimatorsHash.Add(statesHashSequence[i], stringAnimators[i]);
        }
    }
    public void ChangeState(BossState nextState)
    {
        if(nextState != currentState)
        {
            ExitState(currentState);
            currentState = nextState;
            StartState(currentState);
            animator.Play(CreateAnimatorString(currentState));
        }
    }
    private void StartState(BossState state)
    {
        statesHash[state].StartState();
    }
    private void ExitState(BossState state)
    {
        statesHash[state].ExitState();
    }
    private string CreateAnimatorString(BossState state)
    {
        string result = animatorStringHead;
        result = result + stringAnimatorsHash[state];
        return result;
    }
    protected virtual void RunStatePerFrame(BossState state)
    {
        BossState nextState;
        nextState = statesHash[state].RunState(Energy, out energy);
        /*if (isHurtBreak)
        {
            if (health.IsHurt)
            {
                nextState = BossState.Hurt;
            }
        }*/
        if (health.IsDead)
        {
            nextState = BossState.Dead;
        }
        ChangeState(nextState);
    }
}