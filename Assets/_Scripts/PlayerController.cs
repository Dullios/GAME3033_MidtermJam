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
    public readonly int IsAttackingHash = Animator.StringToHash("isAttacking");

    [Header("Movement Properties")]
    [SerializeField]
    private Vector3 moveDirection;
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private bool isRunning;
    [SerializeField]
    private bool isAttacking;

    [Header("Look Properties")]
    [SerializeField]
    private float rotationPower = 10.0f;
    [SerializeField]
    private float horizontalDampening = 1.0f;
    private Vector2 previousMouseDelta = Vector2.zero;

    [Header("Explosive Properties")]
    [SerializeField]
    private float explosiveForce;
    [SerializeField]
    private float explosiveRadius;

    private Vector2 inputVector;

    [Header("Pause Menu")]
    [SerializeField]
    private GameObject pausePanel;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        anim = GetComponent<Animator>();
    }

    private void OnMovement(InputValue value)
    {
        inputVector = value.Get<Vector2>();

        anim.SetFloat(MovementXHash, inputVector.x);
        anim.SetFloat(MovementYHash, inputVector.y);
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
        isAttacking = value.isPressed;
        anim.SetBool(IsAttackingHash, value.isPressed);
    }

    private void OnLook(InputValue value)
    {
        Vector2 lookValue = value.Get<Vector2>();

        Quaternion addedRotation = Quaternion.AngleAxis(Mathf.Lerp(previousMouseDelta.x, lookValue.x, 1.0f / horizontalDampening) * rotationPower, transform.up);

        transform.rotation *= addedRotation;

        previousMouseDelta = lookValue;
    }

    private void OnPause(InputValue value)
    {
        if(pausePanel.activeSelf)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    private void Update()
    {
        if (isAttacking)
        {
            isAttacking = anim.GetBool(IsAttackingHash);
                
            return;
        }

        moveDirection = transform.forward * inputVector.y + transform.right * inputVector.x;

        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isAttacking && collision.gameObject.CompareTag("Orb"))
        {
            collision.rigidbody.AddExplosionForce(explosiveForce, collision.contacts[0].point, explosiveRadius);
            collision.gameObject.GetComponent<OrbBehaviour>().LaunchOrb();
        }
    }
}
