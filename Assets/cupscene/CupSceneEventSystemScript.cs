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
        if (SceneManager.GetActiveScene().name == "catDragAndBoba") {
             // toggle setActive
            List<GameObject> completedBobaList = GameObject.FindGameObjectsWithTag("CompletedBoba").ToList();
            List<GameObject> bobaOrder = GameObject.FindGameObjectsWithTag("BobaOrder").ToList();
            completedBobaList = completedBobaList.Concat(bobaOrder).ToList();
    
            foreach (GameObject boba in completedBobaList) {
                boba.GetComponent<SpriteRenderer> ().enabled = true;
            }
        } else {
            List<GameObject> completedBobaList = GameObject.FindGameObjectsWithTag("CompletedBoba").ToList();
            List<GameObject> bobaOrder = GameObject.FindGameObjectsWithTag("BobaOrder").ToList();
            completedBobaList = completedBobaList.Concat(bobaOrder).ToList();
    
            foreach (GameObject boba in completedBobaList) {
                boba.GetComponent<SpriteRenderer> ().enabled = false;
            }
        }
       
        
    }
}
