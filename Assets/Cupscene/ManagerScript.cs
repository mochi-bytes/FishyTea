using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManagerScript : MonoBehaviour
{
    public static ManagerScript Instance;
    public bool completedGame;

    public bool[] slotOccupied = new bool[3];

    public Color bobaColor;
    public int totalScore;
    public Text totalScoreText;
    Scene scene;
    public bool startSpawning = true;
    private AudioLowPassFilter lowPassFilter;

    void Start() {
        totalScore = 0;
        totalScoreText.text = "$" + totalScore;

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

    public void adjustScore(bool addScore) {
        if (addScore) {
            totalScore += 10;
        } else {
            totalScore -= 5;
        }
        totalScoreText.text = "$" + totalScore;
    }


}
