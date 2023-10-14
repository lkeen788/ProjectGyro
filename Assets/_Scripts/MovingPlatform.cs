using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath waypointPath;

    [SerializeField]
    private float speed;

    private int targetWaypointIndex;

    private Transform previousWaypoint;
    private Transform targetWaypoint;

    private float timeToWaypoint;
    private float elapsedTime;


    void Start()
    {
        TargetNextWaypoint();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        float elapsedPercentage = elapsedTime / timeToWaypoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(previousWaypoint.position, targetWaypoint.position, elapsedPercentage);
        

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
        
    }

    private void TargetNextWaypoint()
    {
        previousWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);
        targetWaypointIndex = waypointPath.GetNextWaypointIndex(targetWaypointIndex);
        targetWaypoint = waypointPath.GetWaypoint(targetWaypointIndex);

        elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(previousWaypoint.position, targetWaypoint.position);
        timeToWaypoint = distanceToWaypoint / speed;
    }
}
