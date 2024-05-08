using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterLogic : MonoBehaviour
{
    public static ShutterLogic Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
