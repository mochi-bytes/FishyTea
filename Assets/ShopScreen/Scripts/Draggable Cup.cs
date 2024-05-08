using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class DraggableCup : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;
    private bool isMovingToMiddle;

    private CompletedBobaSpawner completedBobaSpawnerScript;

    private ManagerScript managerScript;

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
        Renderer orderRenderer = GetComponent<Renderer>();
        thisBobaColor = renderer.color;

        initialPosition = transform.position;

        Debug.Log("bobaspot" + initialPosition.y);
        if (Mathf.Approximately(initialPosition.y, 0.5700001f))
        {
            index = 0;
            renderer.sortingOrder = 2;
        }
        else if (Mathf.Approximately(initialPosition.y, -0.8099999f))
        {
            index = 1;
            renderer.sortingOrder = 3;
        }
        else
        {
            index = 2;
            renderer.sortingOrder = 4;
        }
        initialPosition.z = 0f;
        GameObject completedBobaSpawner = GameObject.Find("CompletedBobaSpawner");
        completedBobaSpawnerScript = completedBobaSpawner.GetComponent<CompletedBobaSpawner>();

        GameObject manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<ManagerScript>();
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
                managerScript.playTrashSound();
                completedBobaSpawnerScript.FreeSlot(index);
                Destroy(gameObject);
                break;
            }
            if (collider.gameObject.CompareTag("BobaOrder"))
            {
                SpriteRenderer customerSpriteRenderer = collider.gameObject.GetComponent<SpriteRenderer>();
                Color customerColor = customerSpriteRenderer.color;

                completedBobaSpawnerScript.FreeSlot(index);
                CustomerOrderFulfill customerOrderFulfill = collider.gameObject.GetComponent<CustomerOrderFulfill>();
                if (customerColor == thisBobaColor)
                {
                    customerOrderFulfill.orderComplete();
                    managerScript.playMoneySound();
                }
                else
                {
                    customerOrderFulfill.orderDone();
                    managerScript.PlayAngrySound();
                }
                Destroy(gameObject);
                break;
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