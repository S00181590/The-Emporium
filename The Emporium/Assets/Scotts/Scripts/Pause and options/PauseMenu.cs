using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string sceneName;
    public GameObject pauseMenu;
    public bool IsPaused;
    public GameObject Options;
    public bool OptionsOpen;
    public GameObject Save;


    public bool SaveMenuOpen;
    public GameObject Load;
    public bool LoadMenuOpen;

    // Start is called before the first frame update
    void Start()
    {

        IsPaused = false;
        OptionsOpen = false;
        SaveMenuOpen = false;
        LoadMenuOpen = false;
    }
    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;

        }
        if (IsPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;

        }

        else if (!IsPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        else if (OptionsOpen)
        {
            Options.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (!OptionsOpen)
        {
            Options.SetActive(false);
            Time.timeScale = 1f;
        }
        //else if(SaveMenuOpen)
        //{
        //    Save.SetActive(true);
        //    Time.timeScale = 0f;
        //}
        //else if(!SaveMenuOpen)
        //{
        //    Options.SetActive(false);
        //    Time.timeScale = 1f;
        //}
        //else if (LoadMenuOpen)
        //{
        //    Save.SetActive(true);
        //    Time.timeScale = 0f;
        //}
        //else if (!LoadMenuOpen)
        //{
        //    Options.SetActive(false);
        //    Time.timeScale = 1f;
        //}
    }



    public void Optionsmenu()
    {
        OptionsOpen = true;
        Options.SetActive(true);
        Time.timeScale = 0f;
    }

    //public void SaveMenu()
    //{
    //    SaveMenuOpen = true;
    //    Save.SetActive(true);
    //    Time.timeScale = 0f;
    //}

    //public void LoadMenu()
    //{
    //    LoadMenuOpen = true;
    //    Save.SetActive(true);
    //    Time.timeScale = 0f;
    //}

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
    public void ResumeTheGame()
    {
        IsPaused = !IsPaused;
        if (!IsPaused)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void SaveSettings()
    {
        OptionsOpen = !OptionsOpen;
        if (!OptionsOpen)
        {
            Options.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
