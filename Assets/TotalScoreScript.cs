using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalScoreScript : MonoBehaviour
{
    public static TotalScoreScript Instance;
    public GameObject[] objectsToExclude;

    // private void Awake()
    // {
    //     DontDestroyOnLoad(gameObject);
    // }
    // Start is called before the first frame update
    private Transform originalParent;

    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // Mark this parent GameObject to not be destroyed on scene load
        DontDestroyOnLoad(transform.parent.gameObject);
    }
}
