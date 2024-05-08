using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EventSystemScript : MonoBehaviour
{
    // Start is called before the first frame update


    void Update()
    {
        if (SceneManager.GetActiveScene().name == "catDragAndBoba") {
             // toggle setActive
            List<GameObject> completedBobaList = GameObject.FindGameObjectsWithTag("CompletedBoba").ToList();
            List<GameObject> bobaOrder = GameObject.FindGameObjectsWithTag("BobaOrder").ToList();
            List<GameObject> shutter = GameObject.FindGameObjectsWithTag("Shutter").ToList();
            completedBobaList = completedBobaList.Concat(bobaOrder).ToList();
            completedBobaList = completedBobaList.Concat(shutter).ToList();
    
            foreach (GameObject boba in completedBobaList) {
                boba.GetComponent<SpriteRenderer>().enabled = true;
                if (boba.transform.childCount > 0) {
                    ToggleAllObjAndChlidren(boba, true);
                }
            }
        } else {
            List<GameObject> completedBobaList = GameObject.FindGameObjectsWithTag("CompletedBoba").ToList();
            List<GameObject> bobaOrder = GameObject.FindGameObjectsWithTag("BobaOrder").ToList();
            List<GameObject> shutter = GameObject.FindGameObjectsWithTag("Shutter").ToList();
            completedBobaList = completedBobaList.Concat(bobaOrder).ToList();
            completedBobaList = completedBobaList.Concat(shutter).ToList();
    
            foreach (GameObject boba in completedBobaList) {
                boba.GetComponent<SpriteRenderer>().enabled = false;
                if (boba.transform.childCount > 0) {
                    ToggleAllObjAndChlidren(boba, false);
                }
            }
        }
       
        
    }

    void ToggleAllObjAndChlidren(GameObject obj, bool disable)
    {
        // Disable the sprite renderer of the current GameObject
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = disable;
        }

        // Disable sprite renderers of all children
        foreach (Transform child in obj.transform)
        {
            SpriteRenderer childSpriteRenderer = child.GetComponent<SpriteRenderer>();
            if (childSpriteRenderer != null)
            {
                childSpriteRenderer.enabled = disable;
            }
        }
    }
}