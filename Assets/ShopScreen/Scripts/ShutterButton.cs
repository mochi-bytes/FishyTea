using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterButton : MonoBehaviour
{
    public float downSpeed = 3f;
    public float upSpeed = 1f;
    private Vector2 destinationPoint = new Vector2(0.04f, 4.16f);

    private Vector2 startPoint = new Vector2(0.04f, 6.4f);

    public static GameObject shutter;

    private bool callShutterUp = false;

    void Awake()
    {
        shutter = GameObject.FindGameObjectWithTag("Shutter");
        // DontDestroyOnLoad(shutter);
    }

    void Update()
    {
        if (callShutterUp)
        {
            moveShutterUp();
        } else {
            moveShutterDown();
        }
      
    }

    void moveShutterUp()
    {
        float step = upSpeed * Time.deltaTime;

        // Move towards the destination
        shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, destinationPoint, step);
        
    }

    void moveShutterDown()
    {
        float step = downSpeed * Time.deltaTime;

        // Move towards the destination
        shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, startPoint, step);
        
    }

    public void initiateShutterUp()
    {
        callShutterUp = !callShutterUp;
    }


}
