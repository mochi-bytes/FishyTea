using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTransparencyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 viewportMousePos = Camera.main.ScreenToViewportPoint(mousePos);
        
        Material material = GetComponent<Renderer>().material;
        material.SetVector("_MousePos", viewportMousePos); // Corrected name
    }
}
