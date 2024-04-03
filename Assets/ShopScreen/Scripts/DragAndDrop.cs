using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private UnityEngine.UI.Image image;

    // private Vector3 newPosition = new Vector3(60.0f, 2.0f, 0.0f); 
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 170); // When dragged, box turns a different color
        transform.SetAsLastSibling(); // set it to be the last sibling so that the cat is always on top of any new boba cups
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Add different animations for cat while being dragged!! 
        transform.position = Input.mousePosition; // cat is dragged by mouse 
        // transform.position = Input.mousePosition + newPosition; 
        // This is to offset it so that the cat looks like it's being picked up by the scruff of its neck
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.color = new Color(255, 255, 255, 255); // At end of drag, change color back to normal 
        
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<UnityEngine.UI.Image>();
    }


}
