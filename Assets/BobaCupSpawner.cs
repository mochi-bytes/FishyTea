using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaCupSpawner : MonoBehaviour
{
    public GameObject bobacup;

    public float spawnRate;

    private float timerFire = 0;

    public double deadZoneX = 0;
    public double startingY = 0;

    public double startingX = 0;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerFire < spawnRate)
        {
            timerFire += Time.deltaTime;
        }
        else
        {
            Spawn();
            timerFire = 0;
        }

        CheckAndDestroyCup();
    }

    void Spawn()
    {
        CheckAndDestroyCup();
        GameObject createdBobaCup = Instantiate(bobacup, new Vector3(0, (float)startingY), transform.rotation);
        createdBobaCup.transform.SetParent(transform, false);
    }

    void CheckAndDestroyCup()
    {
        GameObject[] bobacups = GameObject.FindGameObjectsWithTag("BobaCup");

        foreach (GameObject bobacup in bobacups)
        {
            if (bobacup.transform.position.x < -15)
            {
                Destroy(bobacup);
            }
        }
    }
}

