using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public PointManager PointManager;

    public GameObject storyCanvas;
    public GameObject theEnd;
    public GameObject endButton;
    public Image theEndBar;

    public GameObject dialogue1Set;
    public GameObject[] dialogue1;
    public bool PlayedDialogue1 = false;

    public GameObject dialogue2Set;
    public GameObject[] dialogue2;
    public bool PlayedDialogue2 = false;

    public GameObject dialogue3Set;
    public GameObject[] dialogue3;
    public bool PlayedDialogue3 = false;

    public GameObject losePanel;
    public GameObject endPanel;
    public GameObject greedPanel;

    public int CurrentText;
    public float EndAmount;
    public int dialogue1Thresh;
    public int dialogue2Thresh;
    public int dialogue3Thresh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PointManager.points <= EndAmount)
        {
            theEndBar.fillAmount = PointManager.points / EndAmount;
        }
        else
        {
            theEndBar.fillAmount = 1;
            greedPanel.SetActive(true);
        }

        if(PointManager.points >= dialogue2Thresh && PlayedDialogue2 == false && PlayedDialogue1 == true)
        {
            storyCanvas.SetActive(true);
            dialogue2Set.SetActive(true);
            theEnd.SetActive(true);
        }
        if (PointManager.points >= dialogue3Thresh && PlayedDialogue3 == false && PlayedDialogue2 == true)
        {
            storyCanvas.SetActive(true);
            dialogue3Set.SetActive(true);
            endButton.SetActive(true);
        }
    }

    public void Continue1()
    {
        CurrentText += 1;
        if (CurrentText < dialogue1.Length)
        {
            dialogue1[CurrentText - 1].SetActive(false);
            dialogue1[CurrentText].SetActive(true);
        }
        else
        {
            for (int i = 0; i < dialogue1.Length; i++)
            {
                dialogue1[i].SetActive(false);
            }
            dialogue1Set.SetActive(false);
            storyCanvas.SetActive(false);
            CurrentText = 0;
            PlayedDialogue1 = true;
        }
    }

    public void Continue2()
    {
        CurrentText += 1;
        if (CurrentText < dialogue2.Length)
        {
            dialogue2[CurrentText - 1].SetActive(false);
            dialogue2[CurrentText].SetActive(true);
        }
        else
        {
            for (int i = 0; i < dialogue2.Length; i++)
            {
                dialogue2[i].SetActive(false);
            }
            dialogue2Set.SetActive(false);
            storyCanvas.SetActive(false);
            CurrentText = 0;
            PlayedDialogue2 = true;
        }
    }

    public void Continue3()
    {
        CurrentText += 1;
        if (CurrentText < dialogue3.Length)
        {
            dialogue3[CurrentText - 1].SetActive(false);
            dialogue3[CurrentText].SetActive(true);
        }
        else
        {
            for (int i = 0; i < dialogue3.Length; i++)
            {
                dialogue3[i].SetActive(false);
            }
            dialogue3Set.SetActive(false);
            storyCanvas.SetActive(false);
            CurrentText = 0;
            PlayedDialogue3 = true;
        }
    }

    public void Stop()
    {
        losePanel.SetActive(true);
    }
    public void End()
    {
        endPanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
