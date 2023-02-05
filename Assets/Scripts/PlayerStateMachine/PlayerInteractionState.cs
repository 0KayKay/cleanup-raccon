using UnityEngine;
using System;

internal class PlayerInteractionState : PlayerBaseState
{
    public PlayerInteractionState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        if (!stateMachine.playerRaccoonScript.canDig)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
            Exit();
            return;
        }

        stateMachine.Animator.SetFloat("Movement",0);
        stateMachine.Animator.SetBool("PressF",true);
        stateMachine.playerRaccoonScript.isDigging = true;
    }

    public override void Exit()
    {
        stateMachine.playerRaccoonScript.isDigging = false;
        stateMachine.Animator.SetBool("PressF",false);
    }

    public override void Tick()
    {
        if (stateMachine.InputReader.pressF_cancled)
        {
            stateMachine.playerRaccoonScript.isStopDigging();
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));

        }
        else
        {
            stateMachine.playerRaccoonScript.isPerfomingDigging();
        }
        //CalculateMoveDirection();
        //FaceMoveDirection();
        //Move();
    }
}

