using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PointManager : MonoBehaviour
{
    public TMP_Text pointText;
    public Image endBar;

    public int inc;
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = "Points: " + points.ToString();
    }

    public void PointIncrease()
    {
        points += inc;
    }
}
