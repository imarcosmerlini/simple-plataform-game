using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int _currentWayPointIndex = 0;
    [SerializeField] private float _speed = 2f;
    
    private void Update()
    {
        if (Vector2.Distance(waypoints[_currentWayPointIndex].transform.position, transform.position) < .1f)
        {
            _currentWayPointIndex++;
            if (_currentWayPointIndex >= waypoints.Length)
            {
                _currentWayPointIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position,
            waypoints[_currentWayPointIndex].transform.position, Time.deltaTime * _speed);
    }
}
