using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] List<GameObject> waypoints;


    bool regularMovement;
    bool trackingMovement;
    int waypointIndex = 0;
    float movementThisFrame;
    Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMoves();

    }

    void EnemyMoves() // This determines where the enemy is moving. Waypoints set via the List.
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            targetPosition = waypoints[waypointIndex].transform.position;
            movementThisFrame = speed * Time.deltaTime;
            Vector3 enemyTarget = targetPosition - transform.position;
            transform.right = enemyTarget;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }

        else if (waypointIndex == waypoints.Count)
        {
            //   ropeSystem.ResetRope();
            //      wormShipPrefab.SetActive(false);
            waypointIndex = 0;
        }

    }
}
