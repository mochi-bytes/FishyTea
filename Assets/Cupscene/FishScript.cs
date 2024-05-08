using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FishScript : MonoBehaviour
{

    private SlurpSound slurpSoundScript;

    private void OnMouseDown()
    {
        GameObject slurper = GameObject.Find("EventSystem");
        slurpSoundScript = slurper.GetComponent<SlurpSound>();
        slurpSoundScript.PlaySound();
        Destroy(gameObject);
    }
}
