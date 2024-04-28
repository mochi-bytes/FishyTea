using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;

    private Vector3 middlePoint;
    private bool isMovingToMiddle;
    private Animator animator = null;

    private void Start()
    {
        middlePoint = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, Camera.main.nearClipPlane));
        middlePoint.z = 0f;
        animator = GetComponent<Animator>();
    }


    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
        animator.SetBool("isDragged", true);
    }

    private void OnMouseUp()
    {
        animator.SetBool("isDragged", false);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, transform.localScale, 0);

        if (colliders.Length == 1) {
            moveToMiddle();
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