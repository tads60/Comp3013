using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuColour : MonoBehaviour
{
    public Sprite colouredSprite;
    public Sprite uncolouredSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("coloured") == 1)
        {
            gameObject.GetComponent<Image>().sprite = colouredSprite;
        }
        else if (PlayerPrefs.GetInt("coloured") == 0)
        {
            gameObject.GetComponent<Image>().sprite = uncolouredSprite;
        }
    }
}
