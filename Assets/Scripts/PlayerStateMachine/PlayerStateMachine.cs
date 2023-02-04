using UnityAtoms.BaseAtoms;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{
    public Vector3 Velocity;
    public FloatVariable MovementSpeed;
    public FloatVariable JumpForce;
    public float LookRotationDampFactor { get; private set; } = 10f;
    public Transform MainCamera { get; private set; }
    public InputReader InputReader { get; private set; }
    public Animator Animator;
    public CharacterController Controller { get; private set; }

    public PlayerRaccoonScript playerRaccoonScript;

    private void Start()
    {
        MainCamera = Camera.main.transform;

        InputReader = GetComponent<InputReader>();
       
        Controller = GetComponent<CharacterController>();

        SwitchState(new PlayerIdleState(this));
    }
}