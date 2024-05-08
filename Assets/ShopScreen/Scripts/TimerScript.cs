using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public float totalDuration = 10f; // Total duration of the timer in seconds
    private float currentDuration; // Current remaining duration of the timer

    private SpriteRenderer spriteRenderer;

    private float xScale;
    private float yScale;
    private CustomerOrderFulfill customerOrderFulfillScript;

    private ManagerScript managerScript;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        customerOrderFulfillScript = transform.parent.GetComponent<CustomerOrderFulfill>();

        currentDuration = totalDuration;

        xScale = transform.localScale.x;
        yScale = transform.localScale.y;

        GameObject manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<ManagerScript>();

    }

    void Update()
    {
        currentDuration -= Time.deltaTime;
        float percentageRemaining = currentDuration / totalDuration;

        float localXScale = transform.localScale.x;

        // float subtractPosition = xScale - localXScale;
        // float newXPosition = -subtractPosition;

        // Adjust the width of the timer bar sprite
        Vector3 newScale = new Vector3(percentageRemaining * xScale, yScale, 1f);
        transform.localScale = newScale;

        // Vector3 newPosition = new Vector3(newXPosition, transform.localPosition.y, transform.localPosition.z);
        // transform.localPosition = newPosition;

        Color color = Color.Lerp(Color.green, Color.red, 1f - percentageRemaining);
        spriteRenderer.color = color;

        // If timer runs out, you can handle that here
        if (currentDuration <= 0)
        {
            customerOrderFulfillScript.orderDone();
            managerScript.PlayAngrySound();
        }
    }
}