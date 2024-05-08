using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     CleanupScript.instance.Cleanup();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
