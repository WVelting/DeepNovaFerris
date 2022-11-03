using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;




public class MenuController : MonoBehaviour
{

    //main menu panels
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject chapterPanel;
    public GameObject creditsPanel;
    
    
    //Sets starting panel setup
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

    //switches panel to Chapter Select
    public void OnClickChapterSelect()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        chapterPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    //switches panel to settings panel
    public void OnClickSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        chapterPanel.SetActive(false);
        creditsPanel.SetActive(false);

    }

    //switches panel to credits panel
    public void OnClickCredits()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        chapterPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    //switches panel to main panel
    public void OnClickBackToMain()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        chapterPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    //exits out of game
    public void OnClickExit()
    {
        Application.Quit();
    }

    //opens up Snailent scene
    public void OnClickSnailent()
    {
        SceneManager.LoadScene("Snailent");
    }

}
