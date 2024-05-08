using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSize : MonoBehaviour
{
    public float scaleFactor = 1.5f; // Factor by which to scale up
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("www");
        // Check if collision occurs with the specific object you want
        if (collision.gameObject.CompareTag("CompletedBoba"))
        {
            // Increase the scale
            transform.localScale *= scaleFactor;
            Debug.Log("eeee");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collision ends with the specific object you want
        if (collision.gameObject.CompareTag("CompletedBoba"))
        {
            // Revert the scale to the original scale
            transform.localScale = originalScale;
        }
    }
}
