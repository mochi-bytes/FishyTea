using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DraggableCup : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;
    private bool isMovingToMiddle;

    private CompletedBobaSpawner completedBobaSpawnerScript;

    private Vector3 initialPosition;

    private int index;

    private Color thisBobaColor;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        thisBobaColor = renderer.color;

        initialPosition = transform.position;

        if (Mathf.Approximately(initialPosition.y, 0.04000001f))
        {
            index = 0;
        }
        else if (initialPosition.y == -1.27f)
        {
            index = 1;
        }
        else
        {
            index = 2;
        }
        initialPosition.z = 0f;
        GameObject completedBobaSpawner = GameObject.Find("CompletedBobaSpawner");
        completedBobaSpawnerScript = completedBobaSpawner.GetComponent<CompletedBobaSpawner>();
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
            if (collider.gameObject.CompareTag("TrashCan"))
            {
                completedBobaSpawnerScript.FreeSlot(index);
                Destroy(gameObject);
                break;
            }
            if (collider.gameObject.CompareTag("BobaOrder"))
            {
                Debug.Log("wajkajlkf");
                // have to check if this color matches the order color 
                // CustomerOrderFulfill bobaOrderScript = collider.gameObject.GetComponent<CustomerOrderFulfill>();
                // Color bobaColor = bobaOrderScript.bobaColor;

                SpriteRenderer customerSpriteRenderer = collider.gameObject.GetComponent<SpriteRenderer>();
                Color customerColor = customerSpriteRenderer.color;



                if (customerColor == thisBobaColor)
                {
                    completedBobaSpawnerScript.FreeSlot(index);
                    CustomerOrderFulfill customerOrderFulfill = collider.gameObject.GetComponent<CustomerOrderFulfill>();
                    customerOrderFulfill.orderComplete();
                    // needs to destroy the customer order too
                    Destroy(gameObject);
                    break;
                }

                // completedBobaSpawnerScript.FreeSlot(index);
                // Destroy(gameObject);
                // break;
            }
            if (collider.gameObject == gameObject)
            {
                moveToMiddle();
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
            transform.position = Vector3.MoveTowards(transform.position, initialPosition, 35f * Time.deltaTime);

            // Check if the object has reached the middle point
            if (transform.position == initialPosition)
            {
                isMovingToMiddle = false; // Stop moving
            }
        }


    }

}