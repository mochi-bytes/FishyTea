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

    void Start()
    {
        GameObject customerSpawner = GameObject.Find("CustomerSpawner");
        customerSpawnerScript = customerSpawner.GetComponent<CustomerSpawner>();
        GameObject manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<ManagerScript>();
        
    }

    void OnMouseDown() // Change to a normal method that will be called when user drags the completed order to it
    {
        // to increase score upon dragging
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