using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    public float visionDistance = 10f;
    public float followDistance = 5f;

    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        // Find the player object
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component attached to this game object
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Calculate the distance between the player and this enemy
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the enemy's vision distance
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
                    // The player is within the enemy's vision, start following the player
                    if (distanceToPlayer > followDistance)
                    {
                        agent.SetDestination(player.position);
                    }
                    else
                    {
                        agent.SetDestination(transform.position);
                    }
                }
                else
                {
                    // The player is obstructed by an obstacle, stop following the player
                    agent.SetDestination(transform.position);
                }
            }
        }
        else
        {
            // The player is not within the enemy's vision, stop following the player
            agent.SetDestination(transform.position);
        }
    }
}
