using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 4f;

    int waypointIndex = 0;

    // Use this for initialization
    void Start()
    {
        //The transform of the gameObject using this script
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            Debug.Log("target " + targetPosition.x + ", " + targetPosition.y);
            Debug.Log("Current" + transform.position.x + ", " + transform.position.y);
            Debug.Log(waypointIndex);
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            //If gameObject is at the target position, increment the waypoint index to the next waypoint
            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
