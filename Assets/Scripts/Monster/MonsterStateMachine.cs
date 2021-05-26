using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : MonoBehaviour
{
    [SerializeField]
    private MonsterState initialState;
    [SerializeField]
    private string animatorStringHead;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private List<MonsterState> statesHashSequence;
    [SerializeField]
    private List<MonsterStateBehaviour> states;
    [SerializeField]
    private List<string> stringAnimators;

    private Dictionary<MonsterState, MonsterStateBehaviour> statesHash;
    private Dictionary<MonsterState, string> stringAnimatorsHash;

    private MonsterState currentState;
    public enum MonsterState
    {
        Setup,
        Meet,
        Aggro,
        Attack,
        Hurt,
        Dead,
        Free
    }
    // Start is called before the first frame update
    void Start()
    {
        SetupStatesHash();
        SetupStringAnimatorsHash();
        currentState = initialState;
        StartState(currentState);
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
            ExitState(currentState);
            currentState = nextState;
            StartState(currentState);
            animator.Play(CreateAnimatorString(currentState));
        }
    }
    private void StartState(MonsterState state)
    {
        statesHash[state].StartState();
    }
    private void ExitState(MonsterState state)
    {
        statesHash[state].ExitState();
    }
    private string CreateAnimatorString(MonsterState state)
    {
        string result = animatorStringHead;
        result = result + stringAnimatorsHash[state];
        return result;
    }
    private void RunStatePerFrame(MonsterState state)
    {
        MonsterState nextState;
        nextState = statesHash[state].RunState();
        ChangeState(nextState);
    }
}
