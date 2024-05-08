using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimerScript : MonoBehaviour
{
    public static GameTimerScript Instance;
    public float speed = 1f;
    private float startTime;
    private float journeyLength;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        // Calculate the distance to move based on the screen width
        journeyLength = Screen.width;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the fraction of journey completed
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        // Move the object to the left
        transform.position += Vector3.left * speed * Time.deltaTime;

        // once it gets to x = -17, get to end screen
        if (transform.position.x <= -17.82f) 
        {
            Debug.Log("put in end screen here!!!");
        }
    }
}
