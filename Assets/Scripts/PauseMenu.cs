using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private bool isMenuActive = false;
    [SerializeField] private GameObject menu;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;
        }
        if(isMenuActive)
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
        }
    }

    public void ShowMenu()
    {
        isMenuActive = true;
        menu.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideMenu()
    {
        isMenuActive = false;
        menu.SetActive(false); 
        Time.timeScale = 1;
    }

    public void Resume()
    {
        HideMenu();
        isMenuActive=false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneController.instance.NextLevel();
    }
}
