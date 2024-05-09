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

    public AudioClip[] angrySounds;

    public AudioClip moneySound;

    public AudioClip trashSound;

    private AudioSource angrySoundPlayer;

    public bool isShutterDown;

    void Start()
    {
        totalScore = 0;
        totalScoreText.text = "$" + totalScore;

        // Get the AudioLowPassFilter component attached to the same GameObject
        lowPassFilter = GetComponent<AudioLowPassFilter>();

        angrySoundPlayer = gameObject.AddComponent<AudioSource>();
        isShutterDown = true;

        CleanupScript.instance.AddObjectToDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "CupScene")
        {
            lowPassFilter.cutoffFrequency = 22000;
        }
        else
        {
            lowPassFilter.cutoffFrequency = 3000;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("esc");
            Application.Quit();
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

    public void adjustScore(bool addScore)
    {
        if (addScore)
        {
            totalScore += 10;
        }
        else
        {
            totalScore -= 5;
        }
        totalScoreText.text = "$" + totalScore;
    }

    public void PlayAngrySound()
    {
        // Get a random index within the range of the array
        int randomIndex = UnityEngine.Random.Range(0, angrySounds.Length);

        // Play the audio clip at the randomly selected index
        angrySoundPlayer.PlayOneShot(angrySounds[randomIndex]);
    }

    public void playMoneySound()
    {
        angrySoundPlayer.PlayOneShot(moneySound);
    }

    public void playTrashSound()
    {
        angrySoundPlayer.PlayOneShot(trashSound);
    }
}
