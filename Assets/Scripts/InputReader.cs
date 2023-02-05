using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MoveComposite;
    public Action OnJumpPerformed;
    public Action OnInteractionPerformed;

    public bool pressF_perfomred;
    public bool pressF_started;
    public bool pressF_cancled;

    private Controls controls;

    private void OnEnable()
    {
        if (controls != null)
            return;

        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }

    public void OnDisable()
    {
        controls.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        OnJumpPerformed?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        pressF_started = context.started;
        pressF_perfomred = context.performed;
        pressF_cancled = context.canceled;
        if (!pressF_perfomred)
            return;
        OnInteractionPerformed?.Invoke();
    }
}
