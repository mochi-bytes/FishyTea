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

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ChangeToRandomColor();
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
