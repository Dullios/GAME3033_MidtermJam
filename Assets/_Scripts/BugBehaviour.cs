using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehaviour : MonoBehaviour
{
    [Header("Properties")]
    public ColorType colorType;
    [SerializeField]
    private AIState state;
    [SerializeField]
    private bool isCaptivated;

    [Header("Movement")]
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runSpeed;
    [SerializeField]
    private bool isRunning;
    [SerializeField]
    private float rotateVelocity;
    [SerializeField]
    private Vector3 targetPos;
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

        foreach(GameObject light in lightPosts)
        {
            light.GetComponent<LightPostBehaviour>().lightActivatedEvent.AddListener(LightActivatedHandler);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case AIState.IDLE:
                if(idleRoutine == null && !isCaptivated)
                    idleRoutine = StartCoroutine(IdleRoutine(Random.Range(1, 3)));
                break;
            case AIState.WANDER:
                anim.SetFloat(MovementYHash, 1.0f);

                if(!IsMoving())
                {
                    anim.SetFloat(MovementYHash, 0.0f);
                    state = AIState.IDLE;
                }
                break;
            case AIState.SEEK:
                isCaptivated = true;
                anim.SetFloat(MovementYHash, 1.0f);
                anim.SetBool(IsRunningHash, true);

                if (!IsMoving())
                {
                    anim.SetFloat(MovementYHash, 0.0f);
                    anim.SetBool(IsRunningHash, false);
                    state = AIState.IDLE;
                }
                break;
        }
    }

    public void LightActivatedHandler(GameObject light)
    {
        LightPostBehaviour behaviour = light.GetComponent<LightPostBehaviour>();

        if(!isCaptivated && CompareColor(behaviour.colorType))
        {
            if(idleRoutine != null)
            {
                StopCoroutine(idleRoutine);
                idleRoutine = null;
            }

            lightTarget = light;
            targetPos = light.transform.position;
            targetPos.y = 0.25f;
            state = AIState.SEEK;
        }
        else if(isCaptivated && light == lightTarget)
        {
            if (!CompareColor(behaviour.colorType))
            {
                isCaptivated = false;
                lightTarget = null;
            }
        }
    }

    private bool CompareColor(ColorType c)
    {
        bool compare = false;

        if (colorType == c)
            compare = true;
        else if(colorType == ColorType.GREEN)
        {
            if (c == ColorType.BLUE || c == ColorType.YELLOW)
                compare = true;
        }
        else if (colorType == ColorType.ORANGE)
        {
            if (c == ColorType.RED || c == ColorType.YELLOW)
                compare = true;
        }
        else if (colorType == ColorType.PURPLE)
        {
            if (c == ColorType.BLUE || c == ColorType.RED)
                compare = true;
        }

        return compare;
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

    private bool IsMoving()
    {
        bool temp = true;

        // Rotate to face target position
        Vector3 dir = targetPos - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotateVelocity * Time.deltaTime);

        // Walk forwards
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 movementDirection = transform.forward * (currentSpeed * Time.deltaTime);
        transform.position += movementDirection;

        if (Vector3.Distance(targetPos, transform.position) < targetRange)
        {
            temp = false;
        }

        return temp;
    }
}
