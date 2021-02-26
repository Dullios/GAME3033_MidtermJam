using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    // References
    private Animator anim;

    // Animator Hashes
    public readonly int MovementXHash = Animator.StringToHash("MovementX");
    public readonly int MovementYHash = Animator.StringToHash("MovementY");
    public readonly int IsRunningHash = Animator.StringToHash("isRunning");

    [SerializeField]
    private bool isRunning;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        anim.SetFloat(MovementXHash, input.x);
        anim.SetFloat(MovementYHash, input.y);
    }

    private void OnRun(InputValue value)
    {
        isRunning = value.isPressed;
        anim.SetBool(IsRunningHash, value.isPressed);
    }

    private void OnJump(InputValue value)
    {

    }

    private void OnAttack(InputValue value)
    {

    }

    private void OnLook(InputValue value)
    {

    }
}
