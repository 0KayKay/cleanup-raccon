using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected readonly PlayerStateMachine stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    protected void CalculateMoveDirection()
    {
        //Vector3 cameraForward = new(stateMachine.MainCamera.forward.x, 0, stateMachine.MainCamera.forward.z);
        //Vector3 cameraRight = new(stateMachine.MainCamera.right.x, 0, stateMachine.MainCamera.right.z);

        //Vector3 moveDirection = cameraForward.normalized * stateMachine.InputReader.MoveComposite.y + cameraRight.normalized * stateMachine.InputReader.MoveComposite.x;

        stateMachine.Velocity.x = stateMachine.InputReader.MoveComposite.x * stateMachine.MovementSpeed.Value;
        //stateMachine.Velocity.y = moveDirection.y * stateMachine.MovementSpeed;
        stateMachine.Velocity.z = stateMachine.InputReader.MoveComposite.y * stateMachine.MovementSpeed.Value;
    }

    protected void FaceMoveDirection()
    {
        if (stateMachine.Velocity.x>0)
        {
            stateMachine.playerRaccoonScript.FlipSpriteRight();
        }
        else if (stateMachine.Velocity.x<0)
        {
            stateMachine.playerRaccoonScript.FlipSpriteLeft();
        }
        float zm = stateMachine.Velocity.z > 0 ? 1 : 0;
        stateMachine.Animator.SetFloat("ZMovement",zm);
    }

    protected void ApplyGravity()
    {
        if (stateMachine.Velocity.y > Physics.gravity.y)
        {
            stateMachine.Velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }

    protected void Move()
    {
        var movement = stateMachine.Velocity ;
        stateMachine.Controller.Move(movement * Time.deltaTime);
        stateMachine.Animator.SetFloat("Movement", Mathf.Abs(movement.x)+Mathf.Abs(movement.z));
    }
}