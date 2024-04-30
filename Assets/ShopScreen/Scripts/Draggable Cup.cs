using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DraggableCup : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;

    private Vector3 middlePoint;
    private bool isMovingToMiddle;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        middlePoint = transform.position;
        middlePoint.z = 0f;
    }


    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void OnMouseUp()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);

        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject == gameObject)
            {
                moveToMiddle();
                break;
            }
        }
    }

     private void moveToMiddle()
    {
        isMovingToMiddle = true;
    }


    void Update()
    {
        if (isMovingToMiddle)
        {
            // Move towards the middle point until the object reaches it
            transform.position = Vector3.MoveTowards(transform.position, middlePoint, 35f * Time.deltaTime);

            // Check if the object has reached the middle point
            if (transform.position == middlePoint)
            {
                isMovingToMiddle = false; // Stop moving
            }
        }
    
        
    }



}