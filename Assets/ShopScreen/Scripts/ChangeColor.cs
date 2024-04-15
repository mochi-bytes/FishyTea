using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    Color color1 = new Color(0, 1, 0, 1);
    Color color2 = new Color(1, 0, 0, 1);
    Color color3 = new Color(0, 0, 1, 1);
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
