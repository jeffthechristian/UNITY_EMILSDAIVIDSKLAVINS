using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent navMeshAgent;
    private Animation enemyAnimation;
    public float detectionRange = 10f;
    public float attackRange = 1.5f;
    public float minDistance = 1f;
    public float randomMoveRadius = 5f;
    private Vector3 randomMoveTarget;
    private bool isMovingRandomly = false;
    private bool canSeePlayer = false;
    private bool canMoveTowardsPlayer = false;
    private Vector3 lastKnownPlayerPosition;
    private Vector3 previousPosition;
    private float timeSincePositionChanged;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        enemyAnimation = GetComponent<Animation>();
        SetRandomMoveTarget();
        previousPosition = transform.position;
        timeSincePositionChanged = 0f;
    }

    void Update()
{
    float distance = Vector3.Distance(transform.position, player.transform.position);
    RaycastHit hit;

    if (distance <= detectionRange && Physics.Raycast(transform.position, player.transform.position - transform.position, out hit) && hit.transform.CompareTag("Player"))
    {
        canSeePlayer = true;
        isMovingRandomly = false;
        canMoveTowardsPlayer = true;
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.speed = 5f;
        PlayAnimation("Run");

        // Remember the last known position of the player
        lastKnownPlayerPosition = player.transform.position;
    }
    else
    {
        canSeePlayer = false;

        if (navMeshAgent.remainingDistance < 0.1f)
        {
            if (isMovingRandomly)
            {
                SetRandomMoveTarget();
            }
            else if (lastKnownPlayerPosition != Vector3.zero)
            {
                // If the enemy can no longer see the player and there is a last known position, move towards it
                navMeshAgent.SetDestination(lastKnownPlayerPosition);
                navMeshAgent.speed = 5f;
                PlayAnimation("Run");

                // Check if the enemy is stuck and change path if necessary
                if (navMeshAgent.velocity.magnitude < 0.1f && lastKnownPlayerPosition == navMeshAgent.destination)
                {
                    SetRandomMoveTarget();
                }
                else if (navMeshAgent.remainingDistance < 0.1f)
                {
                    // If the enemy has reached the last known position and still cannot see the player, clear the last known position
                    lastKnownPlayerPosition = Vector3.zero;
                }
            }
            else
            {
                // If not already moving randomly and there is no last known position, start moving randomly
                isMovingRandomly = true;
                SetRandomMoveTarget();
            }
        }

        navMeshAgent.SetDestination(randomMoveTarget);
        navMeshAgent.speed = 2f;
        PlayAnimation("Walk");

        // Check if the enemy is stuck and change path if necessary
        if (navMeshAgent.velocity.magnitude < 0.1f && randomMoveTarget == navMeshAgent.destination)
        {
            SetRandomMoveTarget();
        }
    }

    if (distance <= attackRange && canSeePlayer)
    {
        // If the enemy is close enough to the player to attack and can see the player, stop moving and play the attack animation
        navMeshAgent.isStopped = true;
        PlayAnimation("Attack1");
    }
    else if (distance > minDistance && canMoveTowardsPlayer && !isMovingRandomly)
    {
        // If the enemy is too far from the player to attack and not already moving randomly, move towards the player and play the run animation
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.transform.position);
        navMeshAgent.speed = 5f;
        PlayAnimation("Run");
    }
    else if (canMoveTowardsPlayer && !isMovingRandomly)
    {
        // If the enemy is in the minimum attack range and not already moving randomly, turn towards the player and play the idle animation
        navMeshAgent.isStopped = true;
        transform.LookAt(player.transform);
        PlayAnimation("Idle");
    }
}

// Set a random move target within the randomMoveRadius
void SetRandomMoveTarget()
{
    Vector3 randomDirection = Random.insideUnitSphere * randomMoveRadius;
    randomDirection += transform.position;
    NavMeshHit hit;
    NavMesh.SamplePosition(randomDirection, out hit, randomMoveRadius, 1);
    randomMoveTarget = hit.position;
}

// Play an animation on the enemy
void PlayAnimation(string animName) {
        if (enemyAnimation != null && enemyAnimation.GetClip(animName) != null)
        {
            enemyAnimation.CrossFade(animName);
        }
    }
}




