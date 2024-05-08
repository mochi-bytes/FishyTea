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

    void Start() {
        totalScore = 0;
        totalScoreText.text = "$" + totalScore;
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
