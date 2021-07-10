using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{

    WaveConfig waveConfig;
    int waypointsIndex = 0;
    List<Transform> waypoints;
    float moveSpeed;

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig; // We are setting waveConfig(Whole files) to waveConfig(Only this funtions), Remember pointers in C, Functions variables are different than the whole so we are setting it like this. We are doing this like this because We are going to set waveCongfig from another script
    }

    void Start()
    {
        waypoints = waveConfig.GetWaveWaypointsPrefab();
        transform.position = waypoints[waypointsIndex].transform.position;
        moveSpeed = waveConfig.GetMoveSpeed();

    }

    void Update()
    {
        Movement();

    }
    private void Movement()
    {
        if (waypointsIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointsIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime; // to control the movement speed and make our movement framerate independent;

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointsIndex++;
            }
        }
        else
        {
             Destroy(gameObject);        
        }
    }
}
