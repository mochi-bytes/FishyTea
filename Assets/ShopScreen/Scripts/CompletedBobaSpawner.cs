using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletedBobaSpawner : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points where game objects can be spawned
    public GameObject gameObjectPrefab; // Prefab of the game object to be spawned
                                        // Array to track whether each slot is occupied

    private int orderIndex;

    void Start()
    {

    }

    void Update()
    {
        if (ManagerScript.Instance.completedGame == true)
        {
            SpawnGameObject();
            ManagerScript.Instance.completedGame = false;
        }

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
            GameObject spawnedCompletedBoba = Instantiate(gameObjectPrefab, spawnPoints[slotIndex].position, Quaternion.identity);
            SpriteRenderer renderer = spawnedCompletedBoba.GetComponent<SpriteRenderer>();

            string bobaColor = PlayerPrefs.GetString("ObjectColor", "#EEBC8A"); // Default color white
            renderer.color = HexToColor(bobaColor);
            Debug.Log("GETTING OUT: " + renderer.color);
            renderer.sortingOrder = 5;
            ManagerScript.Instance.slotOccupied[slotIndex] = true; // Mark the slot as occupied
        }
    }

    public bool AllSlotsOccupied()
    {
        // Check if all slots are occupied
        foreach (bool occupied in ManagerScript.Instance.slotOccupied)
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
        for (int i = 0; i < ManagerScript.Instance.slotOccupied.Length; i++)
        {
            if (!ManagerScript.Instance.slotOccupied[i])
            {
                Debug.Log(i);
                return i;
            }
        }
        return -1; // Return -1 if no free slot is found
    }

    public void FreeSlot(int slotIndex)
    {
        // Mark the specified slot as free
        if (slotIndex >= 0 && slotIndex < ManagerScript.Instance.slotOccupied.Length)
        {
            ManagerScript.Instance.slotOccupied[slotIndex] = false;
        }
    }

    Color HexToColor(string hex)
    {
        Color color = Color.clear;
        if (!string.IsNullOrEmpty(hex) && hex.Length >= 6)
        {
            if (hex[0] == '#')
                hex = hex.Substring(1);

            if (hex.Length == 6)
            {
                byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                color = new Color32(r, g, b, 255);
            }
            else if (hex.Length == 8)
            {
                byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                byte a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);

                color = new Color32(r, g, b, a);
            }
        }
        return color;
    }
}