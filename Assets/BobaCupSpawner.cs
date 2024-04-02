using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaCupSpawner : MonoBehaviour
{
    public GameObject bobacup;

    public float spawnRate;

    private float timerFire = 0;

    public double startingY = 0;

    public bool isTop;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
        Debug.Log("is top:" + isTop);
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
        BobaCupMove bobaCupChild = createdBobaCup.GetComponent<BobaCupMove>();
        bobaCupChild.parentTop = isTop;
    }

    void CheckAndDestroyCup()
    {
        GameObject[] bobacups = GameObject.FindGameObjectsWithTag("BobaCup");

        foreach (GameObject bobacup in bobacups)
        {
            if (bobacup.transform.position.x < -10)
            {
                Destroy(bobacup);
            }
            if (bobacup.transform.position.x > 10)
            {
                Destroy(bobacup);
            }
        }
    }
}

