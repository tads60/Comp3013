using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventScript : MonoBehaviour
{
    public bool isColoured = false;
    private GameObject colourIndicator;
    // Start is called before the first frame update
    void Start()
    {
        colourIndicator = GameObject.Find("ColourChanger");
    }

    // Update is called once per frame
    void Update()
    {
        if(!isColoured)
        {
            if(!colourIndicator.activeSelf)
            {
                isColoured = true;
            }
        }

    }
}
