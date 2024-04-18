using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightScript : MonoBehaviour
{

    private SpriteMask spriteMask;

    void Start()
    {
        spriteMask = GetComponent<SpriteMask>();
    }

    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z;
        spriteMask.transform.position = mousePosition;
        
    }
}
