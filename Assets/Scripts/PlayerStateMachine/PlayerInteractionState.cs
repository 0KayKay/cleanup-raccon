using UnityEngine;
using System;

internal class PlayerInteractionState : PlayerBaseState
{
    public PlayerInteractionState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.Animator.SetFloat("Movement",0);
        stateMachine.Animator.SetBool("PressF",true);
    }

    public override void Exit()
    {
        stateMachine.Animator.SetBool("PressF",false);
    }

    public override void Tick()
    {
        if (stateMachine.InputReader.pressF_cancled)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }

        //CalculateMoveDirection();
        //FaceMoveDirection();
        //Move();
    }
}

