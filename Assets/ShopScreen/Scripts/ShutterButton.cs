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

    void Awake()
    {
        shutter = GameObject.FindGameObjectWithTag("Shutter");
        DontDestroyOnLoad(shutter);
    }


    void Update()
    {
        if (ManagerScript.Instance.isShutterDown)
        {
            moveShutterDown();
        } else {
            moveShutterUp();
        }
      
    }

    void moveShutterUp()
    {
        float step = upSpeed * Time.deltaTime;
        shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, destinationPoint, step);
        
    }

    void moveShutterDown()
    {
        float step = downSpeed * Time.deltaTime;
        shutter.transform.position = Vector2.MoveTowards(shutter.transform.position, startPoint, step);
        
    }

    void OnMouseDown()
    {
        ManagerScript.Instance.isShutterDown = !ManagerScript.Instance.isShutterDown;
    }


}
