using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    [SerializeField]
    private Vector3[] waypoints;

    float movementSpeed = 7.0f;
    int currentTargetIndex = 0;
    float distanceToTarget;

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        distanceToTarget = Vector3.Distance(transform.position, waypoints[currentTargetIndex]); // Distance To Target

        if (distanceToTarget < .1) // If close to target, cycle to next waypoint
        {
            currentTargetIndex++;
            if (currentTargetIndex >= waypoints.Length) // At last waypoint
            {
                currentTargetIndex = 0;
            }
        }
        else // Move platform
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTargetIndex], movementSpeed * Time.deltaTime);
        }
    }
}
