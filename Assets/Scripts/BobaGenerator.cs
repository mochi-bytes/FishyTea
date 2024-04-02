using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaGenerator : MonoBehaviour
{
    public GameObject boba;
    public GameObject fish;
    public int numFish;
    public float spawnRadius;

    private Camera mainCamera;
    private float screenLeft;
    private float screenRight;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numFish; i++) {
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            Instantiate(fish, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
