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
    [SerializeField] private float incrementDistance;


    void OnEnable()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        agent = GetComponent<NavMeshAgent>();
        weapon = GetComponent<WeaponController>();
        currentState = "Shooting";
    }

    // Update is called once per frame
    void Update()
    {
        float targetPosition = player.transform.position;
        float agentPosition = agent.transform.position;
        Vector3 direction;

        timeSinceFire += Time.deltaTime;
        switch (currentState)
        {
            case "Shooting":
                {
                    if (Vector3.Distance(agentPosition, targetPosition) > outerKitingRange)
                    {
                        direction = targetPosition - targetPosition;
                        direction.Normalize();
                        agent.SetDestination(agentPosition + direction * incrementDistance);
                    }



                    if (timeSinceFire >= fireRate)
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
                    agent.SetDestination(agent.transform.position + moveDirection * incrementDistance);

                    if (Vector3.Distance(agent.transform.position, player.transform.position) > outerKitingRange)
                    {
                        currentState = "Shooting";
                    }
                }
                break;

            //case "Aggro":
            //    {

            //        //Move toward player
            //        agent.SetDestination(player.transform.position);

            //        //Shoot if there is line of sight
            //        if (timeSinceFire >= fireRate)
            //        {
            //            NavMeshHit hit;
            //            if (!agent.Raycast(player.transform.position, out hit))
            //            {
            //                weapon.Shoot();
            //                timeSinceFire = 0;
            //            }
            //        }
            //        //Exit criterion
            //        if (Time.time > 5000)
            //        {
            //            currentState = "Shooting";
            //        }
            //    }
            //    break;

        }

    }

    void MoveTowards(Vector3 position, bool away=false)
    {
        var moveDirection = (position - agent.transform.position);
        moveDirection.Normalize();
        if (away)
        {
            moveDirection = -moveDirection;
        }
        agent.SetDestination(agent.transform.position + moveDirection * incrementDistance);
    }
}
