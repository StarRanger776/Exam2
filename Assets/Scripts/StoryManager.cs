using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryManager : MonoBehaviour
{
    public PointManager pointManager;

    public GameObject storyCanvas;
    public GameObject theEnd;
    public GameObject endButton;
    public Image theEndBar;

    public GameObject dialogue1Set;
    public GameObject[] dialogue1;
    public bool playedDialogue1 = false;

    public GameObject dialogue2Set;
    public GameObject[] dialogue2;
    public bool playedDialogue2 = false;

    public GameObject dialogue3Set;
    public GameObject[] dialogue3;
    public bool playedDialogue3 = false;

    public GameObject losePanel;
    public GameObject endPanel;
    public GameObject greedPanel;

    public int currentText;
    public float endAmount;
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
        if(pointManager.points <= endAmount)
        {
            theEndBar.fillAmount = pointManager.points / endAmount;
        }
        else
        {
            theEndBar.fillAmount = 1;
            greedPanel.SetActive(true);
        }

        if(pointManager.points >= dialogue2Thresh && playedDialogue2 == false && playedDialogue1 == true)
        {
            storyCanvas.SetActive(true);
            dialogue2Set.SetActive(true);
            theEnd.SetActive(true);
        }
        if (pointManager.points >= dialogue3Thresh && playedDialogue3 == false && playedDialogue2 == true)
        {
            storyCanvas.SetActive(true);
            dialogue3Set.SetActive(true);
            endButton.SetActive(true);
        }
    }

    public void Continue1()
    {
        currentText += 1;
        if (currentText < dialogue1.Length)
        {
            dialogue1[currentText - 1].SetActive(false);
            dialogue1[currentText].SetActive(true);
        }
        else
        {
            for (int i = 0; i < dialogue1.Length; i++)
            {
                dialogue1[i].SetActive(false);
            }
            dialogue1Set.SetActive(false);
            storyCanvas.SetActive(false);
            currentText = 0;
            playedDialogue1 = true;
        }
    }

    public void Continue2()
    {
        currentText += 1;
        if (currentText < dialogue2.Length)
        {
            dialogue2[currentText - 1].SetActive(false);
            dialogue2[currentText].SetActive(true);
        }
        else
        {
            for (int i = 0; i < dialogue2.Length; i++)
            {
                dialogue2[i].SetActive(false);
            }
            dialogue2Set.SetActive(false);
            storyCanvas.SetActive(false);
            currentText = 0;
            playedDialogue2 = true;
        }
    }

    public void Continue3()
    {
        currentText += 1;
        if (currentText < dialogue3.Length)
        {
            dialogue3[currentText - 1].SetActive(false);
            dialogue3[currentText].SetActive(true);
        }
        else
        {
            for (int i = 0; i < dialogue3.Length; i++)
            {
                dialogue3[i].SetActive(false);
            }
            dialogue3Set.SetActive(false);
            storyCanvas.SetActive(false);
            currentText = 0;
            playedDialogue3 = true;
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
