using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChange : MonoBehaviour
{
    private GameObject eventSystem;
    public bool isColoured = false;
    private Light light;
    private Color red = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
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
        if (eventSystem.GetComponent<EventScript>().isColoured)
        {
            isColoured = true;
            light.color = red;
        }
    }
}
