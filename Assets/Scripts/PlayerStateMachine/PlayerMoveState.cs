using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Velocity.y = Physics.gravity.y;
        stateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;
        stateMachine.InputReader.OnInteractionPerformed += SwitchToInteractionState;
    }

    public override void Tick()
    {
        if (!stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }

        CalculateMoveDirection();
        FaceMoveDirection();
        Move();
    }

    public override void Exit()
    {
        stateMachine.InputReader.OnJumpPerformed -= SwitchToJumpState;
        stateMachine.InputReader.OnInteractionPerformed -= SwitchToInteractionState;
    }

    private void SwitchToJumpState()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
    }
    private void SwitchToInteractionState()
    {
        stateMachine.SwitchState(new PlayerInteractionState(stateMachine));
    }

}