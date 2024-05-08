using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color color1 = new Color(0.859f, 0.643f, 0.298f, 1);
    Color color2 = new Color(0.929f, 0.62f, 0.718f, 1);
    Color color3 = new Color(0.714f, 0.902f, 0.635f, 1);
    private Color[] colorChoices;
    private SpriteRenderer rend;
    public Color bobaColor;

    private SpriteRenderer childSpriteRenderer;
    private SpriteRenderer parentSpriteRenderer;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ChangeToRandomColor();

        childSpriteRenderer = GetComponent<SpriteRenderer>();

        if (childSpriteRenderer != null)
        {
            Transform parent = transform.parent;
            if (parent != null)
            {
                // Get the SpriteRenderer component of the parent object
                parentSpriteRenderer = parent.GetComponent<SpriteRenderer>();

                if (parentSpriteRenderer != null)
                {
                    // Change the parent's sprite
                    // parentSpriteRenderer.sprite = childSpriteRenderer.sprite;
                    parentSpriteRenderer.color = childSpriteRenderer.color;
                    // You can apply other properties too if needed

                    // Optionally, you may want to deactivate the child object
                    //gameObject.SetActive(false);
                }
            }
        }
    }

    void Awake()
    {
        colorChoices = new Color[] { color1, color2, color3 };
    }

    void ChangeToRandomColor()
    {
        int randomIndex = Random.Range(0, colorChoices.Length);
        rend.color = colorChoices[randomIndex];
        bobaColor = rend.color;
    }
}
