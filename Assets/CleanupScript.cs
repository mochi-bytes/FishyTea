using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class CleanupScript : MonoBehaviour
{
    // Singleton instance of the GameManager
    public static CleanupScript instance;

    // List to hold references to objects that should be destroyed on scene load
    private List<GameObject> objectsToDestroyOnLoad = new List<GameObject>();

    public int totalScore;
    public Text totalScoreText;

    void Awake()
    {
        // Ensure only one instance of the GameManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
    }

    public void Cleanup()
    {
        // Destroy objects that should be removed when transitioning between scenes
        foreach (GameObject obj in objectsToDestroyOnLoad)
        {
            Destroy(obj);
        }
        // Clear the list after cleanup
        objectsToDestroyOnLoad.Clear();
    }

    public void AddObjectToDestroyOnLoad(GameObject obj)
    {
        // Add the object to the list of objects to destroy on scene load
        objectsToDestroyOnLoad.Add(obj);
    }

    public void RestartGame()
    {
        totalScore = 0;
        totalScoreText.text = "$" + totalScore;
        SceneManager.LoadScene("catDragAndBoba");
    }
}