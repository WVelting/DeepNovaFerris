using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GarageUIManager : MonoBehaviour
{

    public GameObject mainPanel;
    public GameObject techPanel;
    public GameObject journalPanel;
    public GameObject shipPanel;

    void Start()
    {
        mainPanel.SetActive(true);
        shipPanel.SetActive(true);
        techPanel.SetActive(false);
        journalPanel.SetActive(false);
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
    }

    public void OnJournalPanel()
    {
        shipPanel.SetActive(false);
        journalPanel.SetActive(true);
    }

    public void OnTechPanel()
    {
        mainPanel.SetActive(false);
        techPanel.SetActive(true);
    }

    public void OnMainPanel()
    {
        mainPanel.SetActive(true);
        techPanel.SetActive(false);
    }

    public void OnTechTreeButton()
    {

    }


}
