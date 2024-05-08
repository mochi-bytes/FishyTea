using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points where game objects can be spawned
    public GameObject gameObjectPrefab; // Prefab of the game object to be spawned
    public float spawnInterval = 5f; // Interval between spawning new game objects
    private bool[] slotOccupied; // Array to track whether each slot is occupied
    private float timer = 0f;

    private ManagerScript managerScript; 

    public static CustomerSpawner Instance;

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

    void Start()
    {
        GameObject manager = GameObject.Find("Manager");
        managerScript = manager.GetComponent<ManagerScript>();

        slotOccupied = new bool[spawnPoints.Length]; // Initialize the array to track slot occupancy

        if (managerScript.startSpawning) {
            InvokeRepeating("SpawnGameObject", 0f, spawnInterval); // Start spawning game objects
            managerScript.startSpawning = false;
        }
    }

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;
    }

    void SpawnGameObject()
    {       
        // If all slots are occupied, do not spawn a new game object
        if (AllSlotsOccupied())
        {
            return;
        }

        // Find a free slot to spawn the game object
        int slotIndex = FindFreeSlot();
        if (slotIndex != -1)
        {
            // Spawn the game object at the free slot
            GameObject spawnedCustomerOrder = Instantiate(gameObjectPrefab, spawnPoints[slotIndex].position, Quaternion.identity);
            CustomerOrderFulfill customerScript = spawnedCustomerOrder.GetComponent<CustomerOrderFulfill>();
            customerScript.orderIndex = slotIndex;
            slotOccupied[slotIndex] = true; // Mark the slot as occupied
        }
    }

    bool AllSlotsOccupied()
    {
        // Check if all slots are occupied
        foreach (bool occupied in slotOccupied)
        {
            if (!occupied)
            {
                return false;
            }
        }
        return true;
    }

    int FindFreeSlot()
    {
        // Find a free slot to spawn the game object
        for (int i = 0; i < slotOccupied.Length; i++)
        {
            if (!slotOccupied[i])
            {
                return i;
            }
        }
        return -1; // Return -1 if no free slot is found
    }

    public void FreeSlot(int slotIndex)
    {
        // Mark the specified slot as free
        if (slotIndex >= 0 && slotIndex < slotOccupied.Length)
        {
            slotOccupied[slotIndex] = false;
        }
    }

}
