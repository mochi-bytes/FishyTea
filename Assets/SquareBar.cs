using UnityEngine;

public class SquareBar : MonoBehaviour
{
    // Called when another collider enters the trigger collider attached to this GameObject
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object has a Rigidbody2D component
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Stop the movement of the colliding object
            rb.transform.position = new Vector2(transform.position.x, rb.transform.position.y);
        }
    }
}
