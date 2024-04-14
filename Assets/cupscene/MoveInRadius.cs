using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInRadius : MonoBehaviour
{
    public float moveRadius = 5f;
    public float speed = 0.1f;

    // destination of current move
    private Vector2 destinationPoint;
    // start of current move 
    private Vector2 startPoint;  

    void Start()
    {
        startPoint = transform.localPosition;
        PickRandomDestination();
    }

    void Update()
    {
        float step = speed * Time.deltaTime;

        // Move towards the destination
        transform.localPosition = Vector2.MoveTowards(transform.localPosition, destinationPoint, step);

        // Check if reached the destination by comparing current position to destination
        if (Vector2.Distance(transform.localPosition, destinationPoint) < 0.01f)
        {
            // If reached, pick a new random destination
            PickRandomDestination();
        }
    }

    public void PickRandomDestination()
    {
        // Choose a new random destination within circle with the moveRadius and center at startPoint
        destinationPoint = (Random.insideUnitCircle * moveRadius) + startPoint;
    }





   
}
