using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    

    private string currentState;
    private GameObject player;
    private NavMeshAgent agent;
    private WeaponController weapon;

    private float timeSinceFire;
    [SerializeField] private float fireRate;
    [SerializeField] private float innerKitingRange;
    [SerializeField] private float outerKitingRange;
    [SerializeField] private float strikingDistance;
    [SerializeField] private float incrementDistance;
    [SerializeField] private string startState;


    void OnEnable()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        agent = GetComponent<NavMeshAgent>();
        weapon = GetComponent<WeaponController>();
        currentState = startState;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = player.transform.position;
        Vector3 agentPosition = agent.transform.position;
        Vector3 direction;

        timeSinceFire += Time.deltaTime;
        switch (currentState)
        {
            case "Shooting":
                {
                    if (Vector3.Distance(agentPosition, targetPosition) > outerKitingRange)
                    {
                        direction = targetPosition - agentPosition;
                        direction.Normalize();
                        agent.SetDestination(agentPosition + direction * incrementDistance);
                    }

                    agent.transform.LookAt(targetPosition);

                    NavMeshHit hit;
                    bool clearShot = !agent.Raycast(targetPosition, out hit);

                    if (timeSinceFire >= fireRate && clearShot)
                    {
                        weapon.Shoot();
                        timeSinceFire = 0;
                    }

                    if (Vector3.Distance(agent.transform.position, player.transform.position) < innerKitingRange)
                    {
                        currentState = "Kiting";
                    }

                }
                break;

            case "Kiting":
                {
                    direction = agentPosition - targetPosition;
                    direction.Normalize();
                    agent.SetDestination(agentPosition + direction * incrementDistance);

                    if (Vector3.Distance(agent.transform.position, player.transform.position) > outerKitingRange)
                    {
                        currentState = "Shooting";
                    }
                }
                break;

            case "Aggro":
                {
                    agent.SetDestination(targetPosition);
                }
                break;

        }

    }
}
