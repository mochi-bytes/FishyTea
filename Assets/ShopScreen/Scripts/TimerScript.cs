using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float totalDuration = 10f; // Total duration of the timer in seconds
    private float currentDuration; // Current remaining duration of the timer

    private SpriteRenderer spriteRenderer;

    private float xScale;
    private float yScale;
    private CustomerOrderFulfill customerOrderFulfillScript;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        customerOrderFulfillScript = transform.parent.GetComponent<CustomerOrderFulfill>();

        currentDuration = totalDuration;

        xScale = transform.localScale.x;
        yScale = transform.localScale.y;
    }

    void Update()
    {
        currentDuration -= Time.deltaTime;
        float percentageRemaining = currentDuration / totalDuration;

        // Adjust the width of the timer bar sprite
        Vector3 newScale = new Vector3(percentageRemaining * xScale, yScale, 1f);
        transform.localScale = newScale;

        Color color = Color.Lerp(Color.green, Color.red, 1f - percentageRemaining);
        spriteRenderer.color = color;

        // If timer runs out, you can handle that here
        if (currentDuration <= 0)
        {
            customerOrderFulfillScript.orderDone();
        }
    }
}