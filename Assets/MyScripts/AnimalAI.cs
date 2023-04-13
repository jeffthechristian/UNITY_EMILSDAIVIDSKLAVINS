using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Vector3 randomMoveTarget;
    private float minMoveTargetDistance = 5f;
    public float randomMoveRadius;
    public float rotationSpeed = 5f;

    void Start() {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        SetRandomMoveTarget();
    }

    void Update() {
        // Check if the animal has reached the current target
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance) {
            SetRandomMoveTarget();
        }

        // Get the direction to the random move target
        Vector3 direction = randomMoveTarget - transform.position;

        // If the direction is non-zero, rotate towards the target
        if (direction.magnitude > 0.1f) {
            Quaternion targetRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }


    void SetRandomMoveTarget() {
        Vector3 newMoveTarget;
        bool validMoveTarget = false;
        while (!validMoveTarget) {
            // Generate a new random move target
            newMoveTarget = transform.position + Random.insideUnitSphere * randomMoveRadius;
            UnityEngine.AI.NavMeshHit hit;
            if (UnityEngine.AI.NavMesh.SamplePosition(newMoveTarget, out hit, randomMoveRadius, UnityEngine.AI.NavMesh.AllAreas)) {
                newMoveTarget = hit.position;
                // Check if the new move target is far enough from the previous target
                if ((newMoveTarget - randomMoveTarget).magnitude >= minMoveTargetDistance) {
                    validMoveTarget = true;
                    randomMoveTarget = newMoveTarget;
                    navMeshAgent.SetDestination(randomMoveTarget);
                }
            }
        }
    }
}