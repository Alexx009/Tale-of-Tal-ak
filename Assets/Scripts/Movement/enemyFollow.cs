using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class enemyFollow : MonoBehaviour
{
    public float patrolSpeed = 1.5f;
    public float chaseSpeed = 3f;
    public float visionDistance = 10f;
    public float followDistance = 5f;
    public GameObject playerGameObject;
    public enemyKnockBack enemyKnockBackComponent;

    public List<Transform> patrolPoints;
    private int currentPatrolIndex;
    private bool isPatrolling;

    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        // Find the player object
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component attached to this game object
        agent = GetComponent<NavMeshAgent>();

        // Set the agent's speed
        agent.speed = patrolSpeed;

        // Set the current patrol index to the first patrol point
        currentPatrolIndex = 0;

        // Set isPatrolling to true
        isPatrolling = true;
    }

    void Update()
    {
        // Calculate the distance between the player and this enemy
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= visionDistance)
        {
            // Create a ray from this enemy towards the player
            Ray ray = new Ray(transform.position, player.position - transform.position);
            RaycastHit hit;

            // Check if the ray hits the player or an obstacle
            if (Physics.Raycast(ray, out hit, visionDistance))
            {
                // Check if the hit object is the player
                if (hit.transform == player)
                {
                    // The player is within the enemy's vision, start chasing the player
                    agent.speed = chaseSpeed;
                    agent.SetDestination(player.position);
                    isPatrolling = false;
                }
                else
                {
                    // The player is obstructed by an obstacle, stop chasing the player and start patrolling
                    agent.speed = patrolSpeed;
                    isPatrolling = true;
                }
            }
        }
        else
        {
            // The player is not within the enemy's vision, stop chasing the player and start patrolling
            agent.speed = patrolSpeed;
            isPatrolling = true;
        }

        if (isPatrolling)
        {
            // Set the agent's destination to the current patrol point
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);

            // Check if the agent has reached the current patrol point
            if (agent.remainingDistance <= agent.stoppingDistance && !agent.pathPending)
            {
                // Increase the current patrol index
                currentPatrolIndex++;

                // Reset the current patrol index to 0 if it exceeds the number of patrol points
                if (currentPatrolIndex >= patrolPoints.Count)
                {
                    currentPatrolIndex = 0;
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("colliding to player");

            // Calculate the knockback direction
            Vector3 knockbackDirection = (collision.transform.position - transform.position).normalized * -1;

            // Call the EnemyKnockBack method on the enemyKnockBack component
            enemyKnockBackComponent.EnemyKnockBack(knockbackDirection);
        }
    }


}
