using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundColor : MonoBehaviour
{
    public Color bobaColor;

    void Start()
    {

        // Retrieve the color value from PlayerPrefs
        string bobaColor = PlayerPrefs.GetString("ObjectColor", "#EEBC8A"); // Default color white
        Debug.Log("Boba color out: " + bobaColor);
        GetComponent<Camera>().backgroundColor = HexToColor(bobaColor);
        Debug.Log("BG COLOR IS " +  GetComponent<Camera>().backgroundColor);
    }

    Color HexToColor(string hex)
    {
        Color color = Color.clear;
        if (!string.IsNullOrEmpty(hex) && hex.Length >= 6)
        {
            if (hex[0] == '#')
                hex = hex.Substring(1);

            if (hex.Length == 6)
            {
                byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

                color = new Color32(r, g, b, 255);
            }
            else if (hex.Length == 8)
            {
                byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                byte a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);

                color = new Color32(r, g, b, a);
            }
        }
        return color;
    }
}
