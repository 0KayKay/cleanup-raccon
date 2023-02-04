using System;
using UnityEngine;

internal class PlayerIdleState : PlayerBaseState
{
    private readonly int IdleFrontHash = Animator.StringToHash("Raccoon_Idle_Front");
    public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;

        stateMachine.Animator.Play(IdleFrontHash);
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
        }

        private void SwitchToJumpState()
        {
            stateMachine.SwitchState(new PlayerJumpState(stateMachine));
        }
}

