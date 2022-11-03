using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GarageUIManager : MonoBehaviour
{

    public GameObject mainPanel; //main panel
    public GameObject ship1TechPanel; //tech tree for ship one
    public GameObject journalPanel; //chapter select panel
    public GameObject shipPanel; //ship repair and tech tree panel
    public GameObject quetzalTechPanel; //tech tree panel for ship two
    public GameObject dialoguePanel; //shows values and costs for upgrades

    //sets beginning panel layout
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

    //loads scene "snailent"
    public void OnChapterOne()
    {
        SceneManager.LoadScene("Snailent");
    }

    //switches panel to ship panel
    public void OnShipPanel()
    {
        shipPanel.SetActive(true);
        journalPanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    //switches panel to chapter select panel
    public void OnJournalPanel()
    {
        shipPanel.SetActive(false);
        journalPanel.SetActive(true);
        dialoguePanel.SetActive(false);
    }

    //switches panel to tech tree panel of the correct ship
    public void OnTechPanel()
    {
        mainPanel.SetActive(false);
        UnlockedShip();
    }

    //switches panel to main panel
    public void OnMainPanel()
    {
        mainPanel.SetActive(true);
        ship1TechPanel.SetActive(false);
        quetzalTechPanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }

    //determines which ship the player has currently unlocked
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
