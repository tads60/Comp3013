using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colour : MonoBehaviour
{

    private GameObject eventSystem;
    public bool isColoured = false;
    private SpriteRenderer sprites;
    [SerializeField] Sprite newSprite;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem");
        sprites = gameObject.GetComponent<SpriteRenderer>();
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
            sprites.sprite = newSprite;
        }

    }
}
