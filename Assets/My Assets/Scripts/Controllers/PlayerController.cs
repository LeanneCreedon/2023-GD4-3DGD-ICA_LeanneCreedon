using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    const string IDLE = "Idle_A";
    const string WALK = "Walk";

    CustomActions input;

    NavMeshAgent agent;
    Animator animator;

    public delegate void InputEvents();
    public static event InputEvents OnInteract;
    public static event InputEvents OnEnterInteractable;
    public static event InputEvents OnExitInteractable;

    [Header("Movement")]
    [SerializeField] Vector3 moveVector;
    [SerializeField] float lookRotationSpeed = 8f;
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    bool isPointerOverUI = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new CustomActions();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClickToMove();
        input.Main.Interact.performed += ctx => EToInteract();
    }

    void ClickToMove()
    {
        // Making sure the player did not click on the UI
        if (isPointerOverUI)
            return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            if (clickEffect != null)
            { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
        }
    }

    private void EToInteract()
    {
        if (OnInteract != null) OnInteract();
    }

    void OnEnable()
    { input.Enable(); }

    void OnDisable()
    { input.Disable(); }

    void FixedUpdate()
    {
        // Making sure the player did not click on the UI
        if (EventSystem.current.IsPointerOverGameObject())
        {
            isPointerOverUI = true;
            return;
        }
        else
            isPointerOverUI = false;

        FaceTarget();
        SetAnimations();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnEnterInteractable != null) OnEnterInteractable();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (OnExitInteractable != null) OnExitInteractable();
        }
    }

    void FaceTarget()
    {
        if (agent.velocity != Vector3.zero)
        {
            Vector3 direction = (agent.destination - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }

    void SetAnimations()
    {
        if (agent.velocity == Vector3.zero)
        { animator.Play(IDLE); }
        else
        { animator.Play(WALK); }
    }
}