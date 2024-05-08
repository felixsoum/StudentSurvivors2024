using System;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public Enemy enemy;
    Dictionary<string, State> states = new();
    State currentState;

    public void AddState(State state)
    {
        state.stateMachine = this;
        if (currentState == null)
        {
            currentState = state;
            currentState.OnStateEnter();
        }
        states.Add(state.GetType().Name, state);
    }

    public void Transition<T>() where T : State
    {
        currentState = states[typeof(T).Name];
        currentState.OnStateEnter();
    }

    internal void Update()
    {
        currentState.OnStateUpdate();
    }
}

public abstract class State
{
    public StateMachine stateMachine;
    public abstract void OnStateEnter();
    public abstract void OnStateUpdate();
}


public class ChasingState : State
{
    public override void OnStateEnter()
    {
        stateMachine.enemy.spriteRenderer.color = Color.green;
        stateMachine.enemy.moveSpeed = 1f;
    }

    public override void OnStateUpdate()
    {
        if (Vector3.Distance(stateMachine.enemy.transform.position,
            Player.GetInstance().transform.position) < 3f)
        {
            stateMachine.Transition<AttackingState>();
        }
    }
}

public class AttackingState : State
{
    float timer;
    public override void OnStateEnter()
    {
        stateMachine.enemy.spriteRenderer.color = Color.blue;
        timer = 1.5f;
        stateMachine.enemy.Attack();
        stateMachine.enemy.moveSpeed = 0;
    }

    public override void OnStateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachine.Transition<CooldownState>();
        }
    }
}

public class CooldownState : State
{
    float timer;
    public override void OnStateEnter()
    {
        stateMachine.enemy.spriteRenderer.color = Color.red;
        timer = 5f;
        stateMachine.enemy.moveSpeed = -0.5f;
    }

    public override void OnStateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            stateMachine.Transition<ChasingState>();
        }
    }
}

public class Giant : Enemy
{
    StateMachine stateMachine = new();

    // Start is called before the first frame update
    void Start()
    {
        stateMachine.enemy = this;
        stateMachine.AddState(new ChasingState());
        stateMachine.AddState(new AttackingState());
        stateMachine.AddState(new CooldownState());
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public override void Attack()
    {
        // Attaque projectile
    }
}
