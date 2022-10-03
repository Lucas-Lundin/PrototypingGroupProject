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
    [SerializeField] private float corneredRange;
    [SerializeField] private float fleeDistance;


    void OnEnable()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        weapon = GetComponent<WeaponController>();
        currentState = "Shooting";
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceFire += Time.deltaTime;
        nearestEdge = agent.FindClosestEdge();

        switch(currentState)
        {
            case "Shooting":
                if (!agent.pathPending)
                {
                    agent.SetDestination(player.transform.position);
                }

                if (timeSinceFire >= fireRate)
                {
                    weapon.Shoot();
                }
                
                if (Vector3.Distance(transform.position, player.transform.position) < innerKitingRange)
                {
                    currentState = "Kiting";
                }

            case "Kiting":

                if (!agent.pathPending)
                {
                    var escapeDirection = (transform.position - player.transform.position);
                    agent.SetDestination(player.transform.position + escapeDirection.Normalize() * fleeDistance);
                }

                if (Vector3.Distance(transform.position, player.transform.position) > outerKitingRange)
                {
                    currentState = "Shooting";
                } 

            case "Aggro":
                //Move toward player
                if (!agent.pathPending)
                {
                    agent.SetDestination(player.transform.position);
                }
                //Shoot if there is line of sight
                if (timeSinceFire >= fireRate)
                {
                    NavMeshHit hit;
                    if(!agent.Raycast(player.transform.position, out hit))
                    {
                        weapon.Shoot();
                    }
                }

        }

    }
}
