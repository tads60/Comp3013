using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    public bool isColoured = false;
    private Light light;
    private Color red = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isColoured)
        {
            colourCheck();
        }
    }

    void colourCheck()
    {
        if (PlayerPrefs.GetInt("coloured") == 1)
        {
            isColoured = true;
            light.color = red;
        }
    }
}
