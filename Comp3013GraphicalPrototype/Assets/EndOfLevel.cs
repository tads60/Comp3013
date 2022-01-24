using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    [SerializeField] string nextLevelName;
    public bool complete = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(complete)
        {
            Complete();
        }   
    }

    public void Complete()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
