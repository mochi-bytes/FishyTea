using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("catDragAndBoba");
        }
    }

    public void goToShop()
    {
        Debug.Log("poo");
        SceneManager.LoadScene("catDragAndBoba");
    }
}
