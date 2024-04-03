using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaCupMove : MonoBehaviour
{

    public float moveSpeed;

    public bool parentTop;

    public float scaleFactor = 1.2f; // Factor by which to scale up
    private Vector3 originalScale; // Original scale of the object

    void Start()
    {
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (parentTop)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        }
        else
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collision occurs with the specific object you want
        if (collision.gameObject.CompareTag("Player"))
        {
            // Increase the scale
            transform.localScale *= scaleFactor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collision ends with the specific object you want
        if (collision.gameObject.CompareTag("Player"))
        {
            // Revert the scale to the original scale
            transform.localScale = originalScale;
        }
    }

}
