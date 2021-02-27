using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField]
    private ColorType colorType;
    [SerializeField]
    private AIState state;

    [Header("Movement")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private bool isRunning;
    [SerializeField]
    private Vector3 targetPos;
    [SerializeField]
    private float rotateVelocity;
    [SerializeField]
    private float targetRange;

    private Coroutine idleRoutine;

    [SerializeField]
    private GameObject[] lightPosts;
    private GameObject lightTarget;

    [Header("World Bounds")]
    [SerializeField]
    private Vector3 minBounds;
    [SerializeField]
    private Vector3 maxBounds;

    // Components
    private Animator anim;

    // Animator Hashes
    public readonly int MovementXHash = Animator.StringToHash("MovementX");
    public readonly int MovementYHash = Animator.StringToHash("MovementY");
    public readonly int IsRunningHash = Animator.StringToHash("isRunning");

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();

        lightPosts = GameObject.FindGameObjectsWithTag("Light");
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case AIState.IDLE:
                if(idleRoutine == null)
                    idleRoutine = StartCoroutine(IdleRoutine(Random.Range(1, 3)));
                break;
            case AIState.TURNLEFT:
                break;
            case AIState.TURNRIGHT:
                break;
            case AIState.WANDER:
                // Rotate to face target position
                Vector3 dir = targetPos - transform.position;
                Quaternion rot = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotateVelocity * Time.deltaTime);

                anim.SetFloat(MovementYHash, 1.0f);

                // Walk forwards
                float currentSpeed = isRunning ? runSpeed : walkSpeed;

                Vector3 movementDirection = transform.forward * (currentSpeed * Time.deltaTime);
                transform.position += movementDirection;

                if(Vector3.Distance(targetPos, transform.position) < targetRange)
                {
                    anim.SetFloat(MovementYHash, 0.0f);
                    state = AIState.IDLE;
                }
                break;
            case AIState.SEEK:

                break;
        }
    }

    IEnumerator IdleRoutine(float time)
    {
        yield return new WaitForSeconds(time);

        float xPos = Random.Range(minBounds.x, maxBounds.x);
        float zPos = Random.Range(minBounds.z, maxBounds.z);
        targetPos = new Vector3(xPos, minBounds.y, zPos);

        state = AIState.WANDER;

        idleRoutine = null;
    }
}
