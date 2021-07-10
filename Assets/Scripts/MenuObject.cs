using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuObject : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 2f;
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 10f;
    int waypointsIndex = 0;


    void Start()
    {
        if (tag == "Movement")
        {
            transform.position = waypoints[waypointsIndex].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        Rotation();
        if (tag == "Movement")
        {
            Movement();
        }
    }
    public void Rotation()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
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
            waypointsIndex = 0;
        }
    }
}

