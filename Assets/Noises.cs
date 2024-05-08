using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noises : MonoBehaviour
{

    public AudioClip[] angrySounds;

    public AudioClip moneySound;

    public AudioClip trashSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAngrySound()
    {
        // Get a random index within the range of the array
        int randomIndex = Random.Range(0, angrySounds.Length - 1);

        // Play the audio clip at the randomly selected index
        audioSource.PlayOneShot(angrySounds[randomIndex]);
    }

    public void playMoneySound()
    {
        audioSource.PlayOneShot(moneySound);
    }

    public void playTrashSound()
    {
        audioSource.PlayOneShot(trashSound);
    }
}
