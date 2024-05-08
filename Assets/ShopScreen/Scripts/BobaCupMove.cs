using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BobaCupMove : MonoBehaviour
{

    public float moveSpeed;

    public bool parentTop;

    public float scaleFactor = 1f; // Factor by which to scale up
    private Vector3 originalScale; // Original scale of the object

    private bool hoveringOnBoba = false;

    // zoom to cursor position
    private float zoomSpeed = 25f;
    private new Camera camera;

    private Vector3 cursorPosition;
    
    private float currentDistance;
    private SpriteRenderer spriteRenderer;
    private CompletedBobaSpawner completedBobaSpawnerScript;

    void Start()
    {
        camera = Camera.main;
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        GameObject completedBobaSpawner = GameObject.Find("CompletedBobaSpawner");
        completedBobaSpawnerScript = completedBobaSpawner.GetComponent<CompletedBobaSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (parentTop)
        {
            transform.position = transform.position + (Vector3.right * moveSpeed) * Time.deltaTime;

        }
        else
        {
            transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        }

        // if hovering on boba and the left click is released, go to cup scene 
        if (hoveringOnBoba && Input.GetMouseButtonUp(0))
        {
            
            cursorPosition = camera.ScreenToWorldPoint(Input.mousePosition);  // Set the target position to the cursor's position in world space
            cursorPosition.z = camera.transform.position.z; // Maintain the same z-position

            // Start the transition coroutine
            StartCoroutine(TransitionToNextScene());

        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if collision occurs with the specific object you want
        if (collision.gameObject.CompareTag("Player"))
        {
            // Increase the scale
            transform.localScale *= scaleFactor;

            hoveringOnBoba = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collision ends with the specific object you want
        if (collision.gameObject.CompareTag("Player"))
        {
            hoveringOnBoba = false;
            // Revert the scale to the original scale
            transform.localScale = originalScale;
        }
    }

     IEnumerator TransitionToNextScene()
    {
        if (spriteRenderer != null) {
            Color bobaColor = spriteRenderer.color;
            Debug.Log("Boba color in: " + bobaColor);
            PlayerPrefs.SetString("ObjectColor", ColorUtility.ToHtmlStringRGB(bobaColor));
        }
 

        if (completedBobaSpawnerScript.AllSlotsOccupied() == false && ManagerScript.Instance.isShutterDown == false) {
            currentDistance = Vector3.Distance(camera.transform.position, cursorPosition);
            // Zoom in towards the target position
            while (currentDistance > 0.1f)
            {
                camera.transform.position = Vector3.MoveTowards(camera.transform.position, cursorPosition, zoomSpeed * Time.deltaTime);
                currentDistance = Vector3.Distance(camera.transform.position, cursorPosition);
            
                yield return null;
            }

            hoveringOnBoba = false;
            SceneManager.LoadScene("CupScene");
        }
        
    }

}
