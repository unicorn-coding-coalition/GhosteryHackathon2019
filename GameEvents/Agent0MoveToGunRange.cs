using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent0MoveToGunRange : MonoBehaviour
{ 
    // Adjust the speed for the application.
    public float speed = 8.0f;

    // The target position.
    private Transform target;


    void Update()
    {
        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        // Check if the position of the agent and target are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            // Swap the position of the target.
            target.position *= -1.0f;
        }
    }
}
