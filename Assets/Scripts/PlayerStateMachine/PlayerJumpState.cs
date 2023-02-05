using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    private readonly int JumpStartHash = Animator.StringToHash("Raccoon_Jump_Start_Front");
    private const float CrossFadeDuration = 0.1f;

    public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        stateMachine.Velocity = new Vector3(stateMachine.Velocity.x, stateMachine.JumpForce.Value, stateMachine.Velocity.z);

        stateMachine.Animator.SetTrigger("Jump");

    }

    public override void Tick()
    {
        ApplyGravity();

        if (stateMachine.Velocity.y <= 0f)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }

        FaceMoveDirection();
        Move();
    }

    public override void Exit() { }
}