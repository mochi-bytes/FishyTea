using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript Instance;
    public bool completedGame;

    public bool[] slotOccupied = new bool[3];

    public Color bobaColor;

    private AudioLowPassFilter lowPassFilter;

    Scene scene;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        // Get the AudioLowPassFilter component attached to the same GameObject
        lowPassFilter = GetComponent<AudioLowPassFilter>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "CupScene")
        {
            lowPassFilter.cutoffFrequency = 22000;
        } else {
            lowPassFilter.cutoffFrequency = 3000;
        }
    }
}
