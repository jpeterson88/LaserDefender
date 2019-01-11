using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;

    List<Transform> waypoints;

    int waypointIndex = 0;

    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        //The transform of the gameObject using this script
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {

            var targetPosition = waypoints[waypointIndex].position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
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
