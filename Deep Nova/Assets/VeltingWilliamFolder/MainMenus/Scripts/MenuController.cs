using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnClickChapterSelect()
    {
        SceneManager.LoadScene("ChapterSelect");
    }

    public void OnClickSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void OnClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnClickBackToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    public void OnClickSnailent()
    {
        SceneManager.LoadScene("Snailent");
    }
}
