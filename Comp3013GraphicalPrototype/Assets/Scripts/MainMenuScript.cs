using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button exitBtn;
    public Button playBtn;
    public Button resetBtn;
    public Canvas mainMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt("coloured") == 1)
        {
            resetBtn.gameObject.SetActive(true);
        }
        else
        {
            resetBtn.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        //demo
        SceneManager.LoadScene("CastleLevel");
        //full
        //SceneManager.LoadScene("TownLevel");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ResetColour()
    {
        PlayerPrefs.SetInt("coloured", 0);
        resetBtn.gameObject.SetActive(false);
    }
}
