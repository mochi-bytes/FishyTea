using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventSystemScript : MonoBehaviour
{

    public string fishTag = "Fish";
    public Text textToUpdate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(fishTag);
        
        // Get the count of objects
        int count = objectsWithTag.Length;

        // Update the text component with the count
        textToUpdate.text = "" + count;
    }
}
