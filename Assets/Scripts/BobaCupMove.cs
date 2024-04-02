using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaCupMove : MonoBehaviour
{

    public float moveSpeed;

    public bool parentTop;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (parentTop)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        }
        else
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

    }
}
