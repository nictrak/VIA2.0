using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMachine : MonoBehaviour
{
    public MonsterStateBehaviour SetupBehaviour;
    public MonsterStateBehaviour MeetBehaviour;
    public MonsterStateBehaviour AggroBehaviour;
    public MonsterStateBehaviour AttackBehaviour;
    public MonsterStateBehaviour HurtBehaviour;
    public MonsterStateBehaviour DeadBehaviour;
    [SerializeField]
    private MonsterState initialState;
    [SerializeField]
    private string animatorStringHead;
    [SerializeField]
    private Animator animator;

    private MonsterState currentState;
    public enum MonsterState
    {
        Setup,
        Meet,
        Aggro,
        Attack,
        Hurt,
        Dead
    }
    // Start is called before the first frame update
    void Start()
    {
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
        if (state == MonsterState.Setup)
        {
            SetupBehaviour.StartState();
        }
        else if(state == MonsterState.Meet)
        {
            MeetBehaviour.StartState();
        }
        else if (state == MonsterState.Aggro)
        {
            AggroBehaviour.StartState();
        }
        else if (state == MonsterState.Attack)
        {
            AttackBehaviour.StartState();
        }
        else if (state == MonsterState.Hurt)
        {
            HurtBehaviour.StartState();
        }
        else if (state == MonsterState.Dead)
        {
            DeadBehaviour.StartState();
        }
    }
    private void ExitState(MonsterState state)
    {
        if (state == MonsterState.Setup)
        {
            SetupBehaviour.ExitState();
        }
        else if (state == MonsterState.Meet)
        {
            MeetBehaviour.ExitState();
        }
        else if (state == MonsterState.Aggro)
        {
            AggroBehaviour.ExitState();
        }
        else if (state == MonsterState.Attack)
        {
            AttackBehaviour.ExitState();
        }
        else if (state == MonsterState.Hurt)
        {
            HurtBehaviour.ExitState();
        }
        else if (state == MonsterState.Dead)
        {
            DeadBehaviour.ExitState();
        }
    }
    private string CreateAnimatorString(MonsterState state)
    {
        string result = animatorStringHead;
        if (state == MonsterState.Meet)
        {
            result = result + "idle";
        }
        else if (state == MonsterState.Aggro)
        {
            result = result + "aggro";
        }
        else if (state == MonsterState.Attack)
        {
            result = result + "attack";
        }
        else if (state == MonsterState.Hurt)
        {
            result = result + "hurt";
        }
        else if (state == MonsterState.Dead)
        {
            result = result + "dead";
        }
        return result;
    }
    private void RunStatePerFrame(MonsterState state)
    {
        MonsterState nextState = currentState;
        if (state == MonsterState.Setup)
        {
            nextState = SetupBehaviour.RunState();
        }
        else if (state == MonsterState.Meet)
        {
            nextState = MeetBehaviour.RunState();
        }
        else if (state == MonsterState.Aggro)
        {
            nextState = AggroBehaviour.RunState();
        }
        else if (state == MonsterState.Attack)
        {
            nextState = AttackBehaviour.RunState();
        }
        else if (state == MonsterState.Hurt)
        {
            nextState = HurtBehaviour.RunState();
        }
        else if (state == MonsterState.Dead)
        {
            nextState = DeadBehaviour.RunState();
        }
        ChangeState(nextState);
    }
}
