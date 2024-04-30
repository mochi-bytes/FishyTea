using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EventSystemScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "catDragAndBoba") {
             // toggle setActive
            GameObject[] completedBobaList = GameObject.FindGameObjectsWithTag("CompletedBoba");
    
            foreach (GameObject boba in completedBobaList) {
                boba.SetActive(true);
            }
        } else {
            GameObject[] completedBobaList = GameObject.FindGameObjectsWithTag("CompletedBoba");
    
            foreach (GameObject boba in completedBobaList) {
                boba.SetActive(false);
            }
        }
       
        
    }
}
