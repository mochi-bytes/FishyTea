using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishManager : MonoBehaviour
{
     public BobaGenerator bobaGenerator;

    // Start is called before the first frame update
    void Start()
    { 
        bobaGenerator = GameObject.Find("Boba Generator").GetComponent<BobaGenerator>();
    }


    // Update is called once per frame
    void Update()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Fish");
        int count = objectsWithTag.Length;

        if (count == 0)
        {
            ManagerScript.Instance.completedGame = true;
            SceneManager.LoadScene("catDragAndBoba");
        }

        bobaGenerator.fishToCatchText.text = "" + count;
    }

}
