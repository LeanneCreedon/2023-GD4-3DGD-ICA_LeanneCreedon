using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This script is to make the NPC follow player. 
/// Only enabled when objective is complete for the NPC.
/// Reesource: https://www.youtube.com/watch?v=UvDqnbjEEak
/// </summary>
public class NpcFollow : MonoBehaviour
{
    public NavMeshAgent npc;
    public Transform Player;
    public Animator animator;

    public NPC npcScript;

    private void Awake()
    {
        // Get reference to the animator
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        // disabling the interactor script, when npc is following player, their quest is
        // complete, therefore the interaction is no longer required.
        npcScript.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Setting up the movement and animation
        npc.SetDestination(Player.position);
        if (Vector3.Distance(transform.position, Player.position) < 0.1f)
        {
            animator.SetBool("isWalking", false);
        }
        else
            animator.SetBool("isWalking", true);

    }
}
