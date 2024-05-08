using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CustomerOrderFulfill : MonoBehaviour
{
    public int orderIndex;

    private CustomerSpawner customerSpawnerScript;
    private ManagerScript managerScript;
    public static CustomerOrderFulfill Instance;
    private static GameObject instance;

    public Color bobaColor;
    
    public GameObject bobaObj;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameObject customerSpawner = GameObject.Find("CustomerSpawner");
        customerSpawnerScript = customerSpawner.GetComponent<CustomerSpawner>();
        GameObject manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<ManagerScript>();


        // SpriteRenderer boob = bobaObj.GetComponent<SpriteRenderer>();
        // Debug.Log("boob" + bobaObj);
        // bobaColor = boob.color;

        Debug.Log("in customer order " + bobaColor);
    }

    void OnMouseDown() // Change to a normal method that will be called when user drags the completed order to it
    {
        // to increase score upon dragging

    }
    public void orderComplete()
    {
        managerScript.adjustScore(true);
        Destroy(gameObject);
        customerSpawnerScript.FreeSlot(orderIndex);
    }

    public void orderDone()
    {
        managerScript.adjustScore(false);
        Destroy(gameObject);
        customerSpawnerScript.FreeSlot(orderIndex);
    }
}