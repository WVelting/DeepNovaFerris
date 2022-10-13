using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;




public class MenuController : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject chapterPanel;
    public GameObject creditsPanel;
    
    

    void Start()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        chapterPanel.SetActive(false);
        creditsPanel.SetActive(false);


    }

    void Update()
    {
        
    }

    public void OnClickChapterSelect()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        chapterPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void OnClickSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        chapterPanel.SetActive(false);
        creditsPanel.SetActive(false);

    }

    public void OnClickCredits()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        chapterPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void OnClickBackToMain()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        chapterPanel.SetActive(false);
        creditsPanel.SetActive(false);
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
