using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderFulfill : MonoBehaviour
{
    public int orderIndex;

    private CustomerSpawner customerSpawnerScript;

    void Start()
    {
        GameObject customerSpawner = GameObject.Find("CustomerSpawner");
        customerSpawnerScript = customerSpawner.GetComponent<CustomerSpawner>();
        
    }

    void OnMouseDown() // Change to a normal method that will be called when user drags the completed order to it
    {
        orderDone();
    }

    public void orderDone()
    {
        Destroy(gameObject);
        customerSpawnerScript.FreeSlot(orderIndex);
    }
}