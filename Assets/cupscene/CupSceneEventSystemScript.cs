using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EventSystemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> completedBobaList = GameObject.FindGameObjectsWithTag("CompletedBoba").ToList();
            List<GameObject> bobaOrder = GameObject.FindGameObjectsWithTag("BobaOrder").ToList();
            List<GameObject> shutter = GameObject.FindGameObjectsWithTag("Shutter").ToList();
            completedBobaList = completedBobaList.Concat(bobaOrder).ToList();
            completedBobaList = completedBobaList.Concat(shutter).ToList();

        if (SceneManager.GetActiveScene().name == "catDragAndBoba") {
             // toggle setActive
            foreach (GameObject boba in completedBobaList) {
                boba.GetComponent<SpriteRenderer> ().enabled = true;
            }
        } else {
    
            foreach (GameObject boba in completedBobaList) {
                boba.GetComponent<SpriteRenderer> ().enabled = false;
            }
        }
       
        
    }
}
