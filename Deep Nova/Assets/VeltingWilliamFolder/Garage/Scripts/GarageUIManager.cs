using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GarageUIManager : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject ship1TechPanel;
    public GameObject journalPanel;
    public GameObject shipPanel;
    public GameObject quetzalTechPanel;
    public GameObject dialoguePanel;

    void Start()
    {
        mainPanel.SetActive(true);
        shipPanel.SetActive(true);
        ship1TechPanel.SetActive(false);
        quetzalTechPanel.SetActive(false);
        journalPanel.SetActive(false);
        dialoguePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnChapterOne()
    {
        SceneManager.LoadScene("Snailent");
    }

    public void OnShipPanel()
    {
        shipPanel.SetActive(true);
        journalPanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    public void OnJournalPanel()
    {
        shipPanel.SetActive(false);
        journalPanel.SetActive(true);
        dialoguePanel.SetActive(false);
    }

    public void OnTechPanel()
    {
        mainPanel.SetActive(false);
        UnlockedShip();
    }

    public void OnMainPanel()
    {
        mainPanel.SetActive(true);
        ship1TechPanel.SetActive(false);
        quetzalTechPanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    public void UnlockedShip()
    {
        print("switching now");
        switch(PlayerPrefs.GetString("current-ship"))
        {
            case "quetzal-mk-5":
                print("switching to quetzal");
                ship1TechPanel.SetActive(false);
                quetzalTechPanel.SetActive(true);
                break;
            case "":
                ship1TechPanel.SetActive(true);
                quetzalTechPanel.SetActive(false);
                break;

        }


    }


}
