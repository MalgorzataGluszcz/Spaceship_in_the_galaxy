using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] WaveConfigSO _waveConfig;
    List<Transform> _waypoints;
    // Which waypoint we currently are?
    int _waypointIndex = 0;

    void Start()
    {
        _waypoints = _waveConfig.GetWaypoints();
        // Set the enemy to the first waypoints in our list
        transform.position = _waypoints[_waypointIndex].position;
    }

    void Update()
    {
        // On each frame we want to move close to the next waypoint
        FollowPath();
    }

    void FollowPath()
    {
        //
        if (_waypointIndex < _waypoints.Count)
        {
            // Next position of our waypoint we want to move on.
            Vector3 targetPosition = _waypoints[_waypointIndex].position;
            //How fast we are going
            //The distance we are going each frame
            float delta = _waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            //When we reach the next waypoint we have to increament waypoint index.
            if (transform.position == targetPosition)
            {
                _waypointIndex++;
            }
        }
        // If we got to the end of our path
        else
        {
            Destroy(gameObject);
        }
    }
}
