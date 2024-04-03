using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BobaGenerator : MonoBehaviour
{
    public GameObject boba;
    public GameObject fish;
    public int maxFishSpawn;
    public int maxBobaSpawn;
    public float spawnRadius;
    public float minimumDistanceFish;
    public float minimumDistanceBoba;

    public int fishToCatch;
    public Text fishToCatchText;

    // Start is called before the first frame update
    void Start()
    {
        fishToCatch = 0;

        List<Vector2> spawnPositions = new List<Vector2>();


        for (int i = 0; i < maxFishSpawn; i++) {
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            
            // Check if the new position is too close to any previously spawned position
            bool tooClose = false;
            foreach (Vector2 pos in spawnPositions) {
                if (Vector2.Distance(randomPosition, pos) < minimumDistanceFish) {
                    tooClose = true;
                    break;
                }
            }

            // If the position is not too close to any other position, spawn the object
            // We attempt to spawn a certain number of fish (numFish) that amount will not spawn
            //     because of some being randomly generated too close to each other
            if (!tooClose) {
                Instantiate(fish, randomPosition, Quaternion.identity);
                spawnPositions.Add(randomPosition);
                fishToCatch++;
            }
        }

        fishToCatchText.text = "" + fishToCatch;

        for (int i = 0; i < maxBobaSpawn; i++) {
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;
            
            // Check if the new position is too close to any previously spawned position
            bool tooClose = false;
            foreach (Vector2 pos in spawnPositions) {
                if (Vector2.Distance(randomPosition, pos) < minimumDistanceBoba) {
                    tooClose = true;
                    break;
                }
            }

            // If the position is not too close to any other position, spawn the object
            // We attempt to spawn a certain number of fish (numFish) that amount will not spawn
            //     because of some being randomly generated too close to each other
            if (!tooClose) {
                Instantiate(boba, randomPosition, Quaternion.identity);
                spawnPositions.Add(randomPosition);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
