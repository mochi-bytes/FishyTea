using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishScript : MonoBehaviour
{
    // public BobaGenerator bobaGenerator;
    // private int fishToCatch;
    // private Text fishToCatchText;

    // Start is called before the first frame update
    void Start()
    {
        // fishToCatch = bobaGenerator.fishToCatch;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // Perform actions here, e.g., print a message to the console
        Debug.Log("Object Clicked: " + gameObject.name);
        Destroy(gameObject);
        // fishToCatch--;
        // fishToCatchText.text = "" + fishToCatch;

        // You can also perform other actions like changing color, playing sound, etc.
    }
}
