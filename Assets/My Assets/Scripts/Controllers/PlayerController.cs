using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

/// <summary>
/// Refereces Below
/// ***********************************************************************************
/// Tutorial Followed:
/// Click To Move | Unity RPG Tutorial #1 - https://www.youtube.com/watch?v=LVu3_IVCzys
/// accessed - 22/12/2023
/// ---------------------
/// Script for handling the Point & Click Player Controller
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Animations
    const string IDLE = "Idle_A";
    const string WALK = "Walk";

    // Inputs
    CustomActions input;

    // NavMesh & Animator
    NavMeshAgent agent;
    Animator animator;

    // Events
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
    RaycastHit hit;
    Ray ray;

    void Awake()
    {
        // Setting inital values for the components
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new CustomActions();
        AssignInputs();
    }

    void AssignInputs()
    {
        // Assigning Player Inputs
        input.Main.Move.performed += ctx => ClickToMove();
        input.Main.Interact.performed += ctx => EToInteract();
    }

    void ClickToMove()
    {
        // Making sure the player did not click on the UI
        if (isPointerOverUI)
            return;

        // Preventing Player from clicking on an interactable object to move
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Selectable")
            {
                return;
            }
        }

        // Setting up the click effect
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
        {
            agent.destination = hit.point;
            if (clickEffect != null)
            { Instantiate(clickEffect, hit.point + new Vector3(0, 0.1f, 0), clickEffect.transform.rotation); }
        }
    }

    private void EToInteract()
    {
        // E to Interact
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
        // Rotating player to face the target position
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

    // DEBUG - Checking what object the player collided with

    //private void OnCollisionEnter(Collision collisionInfo)
    //{
    //    if (collisionInfo.collider.tag == "Selectable")
    //        Debug.Log("We hit : " + collisionInfo.collider.name);

    //}
}