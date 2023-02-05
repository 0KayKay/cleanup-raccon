using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.SetBool("Falling", true);

    }

    public override void Tick()
    {
        ApplyGravity();
        Move();

        if (stateMachine.Controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerIdleState(stateMachine));
        }
    }

    public override void Exit() {
        stateMachine.Animator.SetBool("Falling", false);
    }
}